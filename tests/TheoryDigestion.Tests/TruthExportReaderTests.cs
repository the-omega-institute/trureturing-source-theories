using System.Security.Cryptography;
using StrataLint.Cli;
using Trureturing.Truth;

namespace StrataLint.Digestion.Tests;

public sealed class TruthExportReaderTests
{
    private const string Name = "ns(n0,7:example)";
    private const string RepoPath = "D5/S1/Words/Identity.lean";
    private static string Commit => new('a', 40);
    private static string Id(char c) => "sha256:" + new string(c, 64);
    private const string FullAxioms = """["Classical.choice", "Quot.sound", "propext"]""";
    private const string Official = """, "libraries": ["Init", "OmegaMath"], "axioms": ["propext"]""";
    private static string Pair(string strictAxioms = "[]") => $$"""
        {"declaration_name_key":"{{Name}}", "kind":"theorem", "statement_type_address":"{{Id('4')}}",
         "official_statement_type_address":"{{Id('5')}}", "libraries":["OmegaInit", "OmegaMath"], "axioms":{{strictAxioms}}}
        """;

    private static byte[] Export(string annotations, string freezeStatus = "frozen") =>
        StructuredCanonicalWriter.WriteJson($$"""
            {"schema":"stratalint.truth-export", "schema_version":2, "dialect":"stratalint.truth-export.v2",
             "source_commit":"{{Commit}}", "source_tree":"{{new string('b', 40)}}", "producer":"TruthExportCommand",
             "nodes":[{"repo_path":"{{RepoPath}}", "freeze_status":"{{freezeStatus}}", "frozen_node_id":"{{Id('1')}}",
             "node_axiom_closure":{{FullAxioms}}, "prerequisite_frozen_node_ids":[], "declarations":[
               {"declaration_name_key":"{{Name}}", "kind":"theorem", "statement_id":"{{Id('2')}}"{{annotations}}}]}]}
            """).ToArray();

    [Theory]
    [InlineData("", null, null)]
    [InlineData(""", "libraries": ["Init"]""", null, null)]
    [InlineData(Official, 1, null)]
    [InlineData(""", "libraries": ["Init"], "axioms": """ + FullAxioms, 3, null)]
    [InlineData(""", "libraries": ["OmegaInit", "OmegaMath"], "axioms": [], "omega_only_axiom_free": true""", 0, true)]
    public void PreservesCanonicalUnpairedExports(string annotations, int? axiomCount, bool? marker)
    {
        var bytes = Export(annotations);
        var model = TruthExportJsonReader.Read(bytes);
        var declaration = Assert.Single(Assert.Single(model.Nodes).Declarations);
        Assert.Null(declaration.StrictOmega);
        Assert.Equal(axiomCount, declaration.Axioms?.Length);
        Assert.Equal(marker, declaration.OmegaOnlyAxiomFree);
        Assert.Equal(bytes, TruthExportJsonWriter.Write(model).ToArray());
    }

    [Theory]
    [InlineData("[]", 0)]
    [InlineData("""["propext"]""", 1)]
    [InlineData(FullAxioms, 3)]
    public void PreservesCanonicalPairsAndUsesTheOfficialCoverIdentity(string strictAxioms, int axiomCount)
    {
        var bytes = Export($"{Official}, \"strict_omega\": {Pair(strictAxioms)}");
        var model = TruthExportJsonReader.Read(bytes);
        var declaration = Assert.Single(Assert.Single(model.Nodes).Declarations);
        Assert.Equal(new[] { "propext" }, declaration.Axioms!.Value.ToArray());
        Assert.Null(declaration.OmegaOnlyAxiomFree);
        var strict = Assert.IsType<StrictOmegaMeasurement>(declaration.StrictOmega);
        Assert.Equal(axiomCount, strict.Axioms.Length);
        Assert.Equal(new[] { "OmegaInit", "OmegaMath" }, strict.Libraries.ToArray());
        Assert.Equal(Id('4'), strict.StatementTypeAddress);
        Assert.Equal(Id('5'), strict.OfficialStatementTypeAddress);
        Assert.Equal(bytes, TruthExportJsonWriter.Write(model).ToArray());

        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllBytes(path, bytes);
            var digest = "sha256:" + Convert.ToHexStringLower(SHA256.HashData(bytes));
            var cover = new PinnedTruthExport(path, Commit, digest).Resolve("D5/S1/Words/Identity.example");
            Assert.Equal(Id('2'), cover.TargetStatementId);
            Assert.Equal(Commit, cover.SourceCommit);
            Assert.Equal(digest, cover.TruthExportSha256);
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Theory]
    [InlineData(Name, "ns(n0,5:other)")]
    [InlineData("theorem", "def")]
    [InlineData("statement_type_address", "statement_id")]
    [InlineData("sha256:", "SHA256:")]
    [InlineData("[]", "null")]
    [InlineData("[]", "[\"sorryAx\"]")]
    [InlineData("[]", "[42]")]
    [InlineData("[]", "[\"propext\", \"propext\"]")]
    [InlineData("[]", "[\"propext\", \"Classical.choice\"]")]
    [InlineData("[]", "[], \"replayed\": true")]
    public void RejectsMalformedOrMismatchedStrictEvidence(string from, string to)
    {
        Assert.Throws<FormatException>(() => TruthExportJsonReader.Read(
            Export($"{Official}, \"strict_omega\": {Pair().Replace(from, to, StringComparison.Ordinal)}")));
    }

    [Fact]
    public void RejectsAmbiguousPublicationClaims()
    {
        Assert.Throws<FormatException>(() => TruthExportJsonReader.Read(Export($"{Official}, \"strict_omega\": null")));
        Assert.Throws<FormatException>(() => TruthExportJsonReader.Read(Export($", \"strict_omega\": {Pair()}")));
        Assert.Throws<FormatException>(() => TruthExportJsonReader.Read(Export(
            $"{Official}, \"strict_omega\": {Pair()}", "proven-not-yet-frozen")));
        Assert.Throws<FormatException>(() => TruthExportJsonReader.Read(Export(
            $"{Official}, \"strict_omega\": {Pair()}, \"omega_only_axiom_free\": true")));
    }
}
