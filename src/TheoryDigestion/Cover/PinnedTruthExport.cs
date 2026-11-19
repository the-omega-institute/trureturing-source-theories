using System.Security.Cryptography;
using StrataLint.Engine;
using Trureturing.Truth;

namespace StrataLint.Cli;

internal sealed class PinnedTruthExport
{
    private readonly Dictionary<string, TruthExportNode> nodes;
    private readonly string commit;
    private readonly string digest;

    internal PinnedTruthExport(string path, string expectedCommit, string expectedDigest)
    {
        TruthExportValidation.RequireGitObjectId(expectedCommit, "expected source commit");
        TruthExportValidation.RequireSha256Id(expectedDigest, "expected export digest");
        var bytes = File.ReadAllBytes(path);
        digest = "sha256:" + Convert.ToHexStringLower(SHA256.HashData(bytes));
        if (digest != expectedDigest) throw new FormatException("truth export digest differs from the supplied pin");

        var model = TruthExportJsonReader.Read(bytes);
        commit = model.SourceCommit;
        if (commit != expectedCommit) throw new FormatException("truth export source commit differs from the supplied revision");
        nodes = model.Nodes.ToDictionary(node => node.RepoPath, StringComparer.Ordinal);
    }

    internal DigestionCoverageEdge Resolve(string text)
    {
        if (!Gid.TryParse(text, out var gid) || gid.ToTarget() is not Target.Formal { Declaration: not null } formal)
            throw new FormatException($"cover requires a canonical declaration GID: {text}");
        if (!nodes.TryGetValue(formal.Path.Value, out var node) || node.FreezeStatus != "frozen")
            throw new FormatException($"target module is absent or unfrozen at {commit}: {formal.Path.Value}");

        string? statementId = null;
        foreach (var declaration in node.Declarations)
        {
            var key = declaration.DeclarationNameKey;
            if (!CoverageSelector.Matches(key, formal.Declaration)) continue;
            if (statementId is not null) throw new FormatException($"declaration selector is ambiguous at {commit}: {text}");
            statementId = declaration.StatementId;
        }
        return new(text, statementId ?? throw new FormatException($"declaration is absent at {commit}: {text}"), commit, digest);
    }
}
