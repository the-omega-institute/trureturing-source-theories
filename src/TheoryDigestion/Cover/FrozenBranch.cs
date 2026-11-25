using System.Collections.Immutable;
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
            RequireFields(record, ["statement_id", "declarations"]);
            var moduleId = ReadString(record, "statement_id");
            TruthExportValidation.RequireSha256Id(moduleId, "module statement_id");
            var declarations = record.GetProperty("declarations");
            if (declarations.ValueKind != JsonValueKind.Array)
                throw new FormatException("invalid declarations in main repository frozen state: expected an array");
            var names = declarations.EnumerateArray().Select(ReadDeclarationName).ToArray();
            module = new(moduleId, "sha256:" + Convert.ToHexStringLower(SHA256.HashData(bytes)), names);
            modules.Add(path, module);
        }
        var matches = module.Names.Where(name => CoverageSelector.Matches(name, formal.Declaration)).ToArray();
        if (matches.Length != 1)
            throw new FormatException($"expected one frozen declaration on {branch} at {commit}, found {matches.Length}: {text}");
        return new(text, null, BranchEvidence: new(branch, commit, module.StatementId, module.Digest, matches[0]));
    }

    private static string ReadDeclarationName(JsonElement declaration)
    {
        RequireFields(declaration, ["declaration_name_key", "kind"], "libraries", "axioms", "strict_omega");
        var name = ReadString(declaration, "declaration_name_key");
        var kind = ReadString(declaration, "kind");
        TruthExportValidation.RequireKind(kind);
        var libraries = ReadOptionalStringArray(declaration, "libraries");
        var axioms = ReadOptionalStringArray(declaration, "axioms");
        if (declaration.TryGetProperty("strict_omega", out var strict))
        {
            if (libraries is null || axioms is null)
                throw new FormatException("strict_omega requires measured official libraries and axioms");
            TruthExportValidation.RequireAnnotation(libraries, "libraries");
            TruthExportValidation.RequireAnnotation(axioms, "axioms");
            StrictOmegaMeasurement.Read(strict).RequireValid(name, kind);
        }
        return name;
    }

    private static string ReadString(JsonElement record, string field) =>
        record.GetProperty(field) is { ValueKind: JsonValueKind.String } value
            ? value.GetString()!
            : throw new FormatException($"invalid {field} in main repository frozen state: expected a string");

    private static ImmutableArray<string>? ReadOptionalStringArray(JsonElement record, string field)
    {
        if (!record.TryGetProperty(field, out var value))
            return null;
        if (value.ValueKind != JsonValueKind.Array)
            throw new FormatException($"invalid {field} in main repository frozen state: expected a string array");
        return value.EnumerateArray().Select(item => item.ValueKind == JsonValueKind.String
            ? item.GetString()!
            : throw new FormatException($"invalid {field} in main repository frozen state: expected a string array"))
            .ToImmutableArray();
    }

    private static void RequireFields(JsonElement record, string[] required, params string[] optional)
    {
        const string invalidFields = "invalid fields in main repository frozen state";
        if (record.ValueKind != JsonValueKind.Object)
            throw new FormatException(invalidFields);

        var missing = required.ToHashSet(StringComparer.Ordinal);
        var availableAnnotations = optional.ToHashSet(StringComparer.Ordinal);
        foreach (var field in record.EnumerateObject())
        {
            if (missing.Remove(field.Name))
                continue;
            if (!availableAnnotations.Remove(field.Name))
                throw new FormatException(invalidFields);
        }
        if (missing.Count != 0)
            throw new FormatException(invalidFields);
    }
}
