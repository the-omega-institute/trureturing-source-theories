using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using StrataLint.Cli;
using StrataLint.Engine;
using Trureturing.Truth;

namespace StrataLint.Digestion.Tests;

public sealed class FrozenBranchTests
{
    private const string Gid = "D5/S1/Words/Identity.example";
    private const string Other = "D5/S1/Words/Identity.other";
    private const string Name = "ns(n0,7:example)";
    private static string Commit(char c) => new(c, 40);
    private static string Id(char c) => "sha256:" + new string(c, 64);
    private static byte[] State(params string[] names) =>
        StateWithDeclarations(names.Select(n => new { declaration_name_key = n, kind = "theorem" }).ToArray());

    private static byte[] StateWithDeclarations(params object[] declarations) => JsonSerializer.SerializeToUtf8Bytes(new
    {
        statement_id = Id('1'),
        declarations,
    });

    [Fact]
    public void BatchUsesOneStatePerModuleAndStoresMembershipWithoutDeclarationDigest()
    {
        var reads = new List<string>();
        var branch = new FrozenBranch("dev", Commit('a'), path =>
        {
            reads.Add(path);
            return State("ns(n0,5:other)", Name);
        });
        var first = branch.Resolve(Gid);
        Assert.Null(first.TargetStatementId);
        Assert.True(first.HasEvidence);
        Assert.Equal(Name, first.BranchEvidence!.DeclarationNameKey);
        Assert.Equal("dev", first.BranchEvidence.Branch);
        Assert.Equal(Commit('a'), first.BranchEvidence.Commit);
        Assert.Equal(Id('1'), first.BranchEvidence.ModuleStatementId);
        Assert.Equal(first.BranchEvidence.StateSha256, branch.Resolve(Other).BranchEvidence!.StateSha256);
        Assert.Equal(new[] { "D5/S1/Words/Identity.lean" }, reads);
    }

    [Fact]
    public void LegacyAndIndependentlyAnnotatedDeclarationsShareTheRawStateDigest()
    {
        var state = StateWithDeclarations(
            new { declaration_name_key = Name, kind = "theorem" },
            new { declaration_name_key = "ns(n0,5:other)", kind = "theorem", libraries = new[] { "Mathlib" } },
            new { declaration_name_key = "ns(n0,4:zero)", kind = "theorem", axioms = Array.Empty<string>() },
            new { declaration_name_key = "ns(n0,4:both)", kind = "theorem", libraries = Array.Empty<string>(), axioms = new[] { "Classical.choice" } });
        var branch = new FrozenBranch("dev", Commit('a'), _ => state);
        var digest = "sha256:" + Convert.ToHexStringLower(SHA256.HashData(state));
        foreach (var (gid, name) in new[]
        {
            (Gid, Name),
            (Other, "ns(n0,5:other)"),
            ("D5/S1/Words/Identity.zero", "ns(n0,4:zero)"),
            ("D5/S1/Words/Identity.both", "ns(n0,4:both)"),
        })
        {
            var evidence = branch.Resolve(gid).BranchEvidence!;
            Assert.Equal(name, evidence.DeclarationNameKey);
            Assert.Equal(digest, evidence.StateSha256);
        }
    }

    [Fact]
    public void PairedStateResolvesOfficialMembershipAndKeepsTheRawDigest()
    {
        var state = StateWithDeclarations(
            new
            {
                declaration_name_key = Name,
                kind = "theorem",
                libraries = new[] { "Init", "OmegaMath" },
                axioms = new[] { "propext" },
                strict_omega = new StrictOmegaMeasurement(Name, "theorem", Id('2'), Id('3'), ["OmegaInit", "OmegaMath"], []),
            },
            new { declaration_name_key = "ns(n0,5:other)", kind = "theorem" });
        var branch = new FrozenBranch("dev", Commit('a'), _ => state);
        var evidence = branch.Resolve(Gid);
        Assert.Null(evidence.TargetStatementId);
        Assert.Equal(Name, evidence.BranchEvidence!.DeclarationNameKey);
        Assert.Equal(Id('1'), evidence.BranchEvidence.ModuleStatementId);
        Assert.Equal("sha256:" + Convert.ToHexStringLower(SHA256.HashData(state)), evidence.BranchEvidence.StateSha256);
        Assert.Equal(evidence.BranchEvidence.StateSha256, branch.Resolve(Other).BranchEvidence!.StateSha256);
    }

    [Theory]
    [InlineData("ns(n0,5:other)", "theorem", true)]
    [InlineData(Name, "def", true)]
    [InlineData(Name, "theorem", false)]
    public void RejectsPairsWithCrossedIdentityOrMissingOfficialMeasurement(string name, string kind, bool hasOfficialAxioms)
    {
        var strict = new StrictOmegaMeasurement(name, kind, Id('2'), Id('3'), [], []);
        var declaration = new Dictionary<string, object>
        {
            ["declaration_name_key"] = Name,
            ["kind"] = "theorem",
            ["libraries"] = new[] { "Init" },
            ["strict_omega"] = strict,
        };
        if (hasOfficialAxioms) declaration.Add("axioms", new[] { "propext" });
        var branch = new FrozenBranch("dev", Commit('a'), _ => StateWithDeclarations(declaration));
        Assert.Throws<FormatException>(() => branch.Resolve(Gid));
    }

    [Theory]
    [InlineData(""" "unknown":[] """)]
    [InlineData(""" "Libraries":[] """)]
    [InlineData(""" "libraries":[],"libraries":["Mathlib"] """)]
    [InlineData(""" "axioms":["Classical.choice"],"axioms":[] """)]
    [InlineData(""" "libraries":"Mathlib" """)]
    [InlineData(""" "libraries":["Mathlib",42] """)]
    [InlineData(""" "axioms":null """)]
    [InlineData(""" "axioms":{} """)]
    [InlineData(""" "axioms":[null] """)]
    [InlineData(""" "strict_omega":null """)]
    [InlineData(""" "strict_omega":{},"strict_omega":{} """)]
    public void InvalidAnnotationFieldsRejectTheWholeModule(string fields)
    {
        using var declaration = JsonDocument.Parse($$"""
            {"declaration_name_key":"ns(n0,5:other)","kind":"theorem",{{fields}}}
            """);
        var state = StateWithDeclarations(new { declaration_name_key = Name, kind = "theorem" }, declaration.RootElement);
        var branch = new FrozenBranch("dev", Commit('a'), _ => state);
        Assert.Throws<FormatException>(() => branch.Resolve(Gid));
    }

    [Fact]
    public void MatchingStateOnLaterBranchCommitIsIdempotentAndExportProvenanceSurvives()
    {
        var older = new FrozenBranch("dev", Commit('a'), _ => State(Name)).Resolve(Gid);
        var newer = new FrozenBranch("dev", Commit('b'), _ => State(Name)).Resolve(Gid);
        Assert.Equal(older, PinnedCoverCommand.MergeEvidence(older, newer));
        var exported = new DigestionCoverageEdge(Gid, Id('2'), Commit('c'), Id('3'));
        var both = PinnedCoverCommand.MergeEvidence(exported, newer);
        Assert.Equal(exported.TargetStatementId, both.TargetStatementId);
        Assert.Equal(exported.SourceCommit, both.SourceCommit);
        Assert.Equal(newer.BranchEvidence, both.BranchEvidence);
        Assert.Equal(both, PinnedCoverCommand.MergeEvidence(newer, exported));
        var otherBranch = new FrozenBranch("review", Commit('c'), _ => State(Name)).Resolve(Gid);
        Assert.Equal("review", PinnedCoverCommand.MergeEvidence(older, otherBranch).BranchEvidence!.Branch);
    }

    [Fact]
    public void MissingAmbiguousAndMalformedRecordsCannotAddCoverage()
    {
        foreach (var state in new[] { State("ns(n0,5:other)"), State(Name, "ns(ns(n0,1:A),7:example)"),
                     Encoding.UTF8.GetBytes("{\"declarations\":[],\"declarations\":[],\"statement_id\":\"bad\"}") })
        {
            Assert.Throws<FormatException>(() => new FrozenBranch("dev", Commit('a'), _ => state).Resolve(Gid));
        }
    }
}
