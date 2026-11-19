using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using StrataLint.Engine;
using Trureturing.Truth;

namespace StrataLint.Cli;

internal sealed class FrozenBranch(string branch, string commit, Func<string, byte[]> readShard)
{
    private const string Repo = "the-omega-institute/trureturing";
    private static readonly HttpClient Client = new() { Timeout = TimeSpan.FromSeconds(60) };
    private sealed record Module(string StatementId, string Digest, string[] Names);
    private readonly Dictionary<string, Module> modules = new(StringComparer.Ordinal);

    internal static FrozenBranch Open(string root, string branch)
    {
        var reference = "refs/heads/" + branch;
        GitRepositoryGateway.Git(root, ["check-ref-format", reference]);
        var answer = Encoding.UTF8.GetString(GitRepositoryGateway.Git(root,
            ["ls-remote", "--exit-code", "--refs", $"https://github.com/{Repo}.git", reference])).TrimEnd('\n');
        var fields = answer.Split('\t');
        if (fields.Length != 2 || fields[1] != reference)
            throw new FormatException($"main repository branch ref did not resolve uniquely: {reference}");
        var commit = fields[0];
        TruthExportValidation.RequireGitObjectId(commit, "branch commit");
        return new(branch, commit, path =>
        {
            var uri = $"https://raw.githubusercontent.com/{Repo}/{commit}/Golden/Frozen/state/{path}.json";
            try { return Client.GetByteArrayAsync(uri).GetAwaiter().GetResult(); }
            catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            { throw new FormatException($"module is not frozen on {branch} at {commit}: {path}", e); }
        });
    }

    internal DigestionCoverageEdge Resolve(string text)
    {
        if (!Gid.TryParse(text, out var gid) || gid.ToTarget() is not Target.Formal { Declaration: not null } formal)
            throw new FormatException($"cover requires a canonical declaration GID: {text}");
        var path = formal.Path.Value;
        if (!modules.TryGetValue(path, out var module))
        {
            var bytes = readShard(path);
            using var doc = JsonDocument.Parse(bytes);
            var record = doc.RootElement;
            RequireFields(record, "statement_id", "declarations");
            var moduleId = record.GetProperty("statement_id").GetString() ?? throw new FormatException("missing module statement_id");
            TruthExportValidation.RequireSha256Id(moduleId, "module statement_id");
            var names = record.GetProperty("declarations").EnumerateArray().Select(d =>
            {
                RequireFields(d, "declaration_name_key", "kind");
                TruthExportValidation.RequireKind(d.GetProperty("kind").GetString() ?? "");
                return d.GetProperty("declaration_name_key").GetString() ?? throw new FormatException("missing declaration name");
            }).ToArray();
            module = new(moduleId, "sha256:" + Convert.ToHexStringLower(SHA256.HashData(bytes)), names);
            modules.Add(path, module);
        }
        var matches = module.Names.Where(name => CoverageSelector.Matches(name, formal.Declaration)).ToArray();
        if (matches.Length != 1)
            throw new FormatException($"expected one frozen declaration on {branch} at {commit}, found {matches.Length}: {text}");
        return new(text, null, BranchEvidence: new(branch, commit, module.StatementId, module.Digest, matches[0]));
    }

    private static void RequireFields(JsonElement record, params string[] fields)
    {
        if (record.ValueKind != JsonValueKind.Object ||
            !record.EnumerateObject().Select(field => field.Name).Order(StringComparer.Ordinal)
                .SequenceEqual(fields.Order(StringComparer.Ordinal)))
            throw new FormatException("invalid fields in main repository frozen state");
    }
}
