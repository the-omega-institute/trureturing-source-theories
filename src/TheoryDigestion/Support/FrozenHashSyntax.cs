using System.Text.RegularExpressions;
namespace StrataLint.Engine;

internal static partial class FrozenHashSyntax
{
    [GeneratedRegex("^sha256:[0-9a-f]{64}$", RegexOptions.CultureInvariant)]
    private static partial Regex Sha256Pattern();

    [GeneratedRegex("^(?:git-sha1:[0-9a-f]{40}|git-sha256:[0-9a-f]{64})$", RegexOptions.CultureInvariant)]
    private static partial Regex GitOidPattern();

    internal static bool IsSha256(string value) => Sha256Pattern().IsMatch(value);

    internal static bool IsGitOid(string value) => GitOidPattern().IsMatch(value);
}
