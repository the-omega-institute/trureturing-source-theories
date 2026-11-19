using System.Text;
using System.Text.Json;
using StrataLint.Cli;
using StrataLint.Engine;

namespace StrataLint.Digestion.Tests;

public sealed class FrozenBranchTests
{
    private const string Gid = "D5/S1/Words/Identity.example";
    private const string Other = "D5/S1/Words/Identity.other";
    private const string Name = "ns(n0,7:example)";
    private static string Commit(char c) => new(c, 40);
    private static string Id(char c) => "sha256:" + new string(c, 64);
    private static byte[] State(params string[] names) => JsonSerializer.SerializeToUtf8Bytes(new
    {
        statement_id = Id('1'),
        declarations = names.Select(n => new { declaration_name_key = n, kind = "theorem" }),
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
