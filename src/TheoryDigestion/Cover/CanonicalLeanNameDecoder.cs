using System.Buffers;
using System.Text;

namespace StrataLint.Engine;

internal static class CanonicalLeanNameDecoder
{
    internal static string DecodePrefix(string input, int start, out int consumedCharacters)
    {
        ArgumentNullException.ThrowIfNull(input);
        if ((uint)start > (uint)input.Length) throw new ArgumentOutOfRangeException(nameof(start));

        var parser = new Parser(input, start);
        var decoded = parser.Name(requireRepositoryIdentifier: false);
        consumedCharacters = parser.Position - start;
        return decoded;
    }

    // Structural Name components for consumers that must preserve str/num and
    // UTF-8 atoms, rather than split the lossy display spelling on dots.
    internal static (string Kind, string Value)[] ComponentsPrefix(
        string input, int start, out int consumedCharacters)
    {
        ArgumentNullException.ThrowIfNull(input);
        if ((uint)start > (uint)input.Length) throw new ArgumentOutOfRangeException(nameof(start));
        var components = new List<(string Kind, string Value)>();
        var parser = new Parser(input, start, components);
        _ = parser.Name(requireRepositoryIdentifier: false);
        consumedCharacters = parser.Position - start;
        return components.ToArray();
    }

    internal static bool IsRepositoryNameKey(string input)
    {
        try
        {
            var parser = new Parser(input, 0);
            _ = parser.Name(requireRepositoryIdentifier: true);
            return parser.Position == input.Length;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private sealed class Parser(string text, int start, List<(string Kind, string Value)>? components = null)
    {
        internal int Position { get; private set; } = start;

        internal string Name(bool requireRepositoryIdentifier, int depth = 0)
        {
            if (components is not null && depth > 256) throw Error("Name depth exceeds source bound.");
            if (TryTake("n0")) return string.Empty;

            var tag = Word(2);
            Take("(");
            var parent = Name(requireRepositoryIdentifier, depth + 1);
            Take(",");
            var part = tag switch
            {
                "ns" => StringPart(requireRepositoryIdentifier),
                "nn" => CanonicalDecimal(),
                _ => throw Error("Unknown name tag."),
            };
            Take(")");
            components?.Add((tag, part));
            return parent.Length == 0 ? part : parent + "." + part;
        }

        private string StringPart(bool requireRepositoryIdentifier)
        {
            var value = Atom();
            if (requireRepositoryIdentifier && !IsRepositoryIdentifier(value))
            {
                throw Error("Name component is outside repository identifier policy.");
            }

            return value;
        }

        private string Atom()
        {
            var lengthText = CanonicalDecimal();
            if (!int.TryParse(
                    lengthText,
                    System.Globalization.NumberStyles.None,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out var byteLength))
            {
                throw Error("Atom length exceeds supported input size.");
            }

            Take(":");
            var atomStart = Position;
            var bytes = 0;
            while (bytes < byteLength)
            {
                if (Position == text.Length
                    || Rune.DecodeFromUtf16(
                        text.AsSpan(Position),
                        out var rune,
                        out var consumed) != OperationStatus.Done
                    || bytes + rune.Utf8SequenceLength > byteLength)
                {
                    throw Error("Atom does not match its UTF-8 byte length.");
                }

                Position += consumed;
                bytes += rune.Utf8SequenceLength;
            }

            return text[atomStart..Position];
        }

        private string CanonicalDecimal()
        {
            var start = Position;
            while (Position < text.Length && text[Position] is >= '0' and <= '9') Position++;
            if (start == Position) throw Error("Expected unsigned integer.");
            if (text[start] == '0' && Position - start > 1)
            {
                throw Error("Unsigned integer has leading zeroes.");
            }

            return text[start..Position];
        }

        private string Word(int length)
        {
            if (Position + length > text.Length) throw Error("Unexpected end.");
            var result = text.Substring(Position, length);
            Position += length;
            return result;
        }

        private void Take(string value)
        {
            if (!TryTake(value)) throw Error($"Expected {value}.");
        }

        private bool TryTake(string value)
        {
            if (!text.AsSpan(Position).StartsWith(value, StringComparison.Ordinal)) return false;
            Position += value.Length;
            return true;
        }

        private FormatException Error(string message) => new(
            $"{message} At byte {Encoding.UTF8.GetByteCount(text.AsSpan(0, Position))}.");
    }

    private static bool IsRepositoryIdentifier(string value)
    {
        if (value.Length == 0 || value[0] is not ((>= 'A' and <= 'Z') or (>= 'a' and <= 'z') or '_'))
        {
            return false;
        }

        foreach (var character in value.AsSpan(1))
        {
            if (character is not ((>= 'A' and <= 'Z')
                or (>= 'a' and <= 'z')
                or (>= '0' and <= '9')
                or '_'
                or '\''))
            {
                return false;
            }
        }

        return true;
    }
}
