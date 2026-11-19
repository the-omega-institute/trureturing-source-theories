namespace StrataLint.Engine;

internal static class CoverageSelector
{
    internal static bool Matches(string key, string declaration)
    {
        var decoded = CanonicalLeanNameDecoder.DecodePrefix(key, 0, out var consumed);
        if (consumed != key.Length) throw new FormatException("invalid encoded declaration name");
        if (decoded[(decoded.LastIndexOf('.') + 1)..] != declaration) return false;
        if (!CanonicalLeanNameDecoder.IsRepositoryNameKey(key)) throw new FormatException("invalid matching repository declaration name");
        return true;
    }
}
