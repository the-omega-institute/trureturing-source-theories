using System.Collections.Immutable;
using StrataLint.Engine;

namespace StrataLint.TestSupport;

internal static class DigestionTestSupport
{
    internal static BackfillInventoryDocument EmptyDocument(string atomizerId) =>
        Document(atomizerId, []);

    internal static BackfillInventoryDocument Document(
        string atomizerId,
        ImmutableArray<DigestionLedgerEntry> entries,
        string sourceId = "source",
        string sourcePath = "docs/develop/theory/source.md",
        GenreRegistryCheck? genreRegistryCheck = null,
        ImmutableArray<string> acknowledgedStale = default,
        ImmutableArray<BackfillTicketReference> tickets = default) =>
        BackfillInventoryDocument.Create(
        [
            new DigestionLedgerSource(
                sourceId,
                sourcePath,
                atomizerId,
                acknowledgedStale.IsDefault ? [] : acknowledgedStale,
                GenreRegistryProjection.Available(
                    genreRegistryCheck ?? GenreRegistryCheck.NoGenreRegistry),
                entries),
        ],
        tickets.IsDefault ? [] : tickets);

    internal static DigestionLedgerEntry Entry(
        DigestionAtom atom,
        string atomId,
        string atomizerId,
        DigestionMigrationState migration = DigestionMigrationState.Residual,
        DigestionTruthState truth = DigestionTruthState.Open,
        ImmutableArray<string> coverageGids = default,
        DigestionReceipts? receipts = null,
        string sourceId = "source",
        string sourcePath = "docs/develop/theory/source.md",
        string? casRef = null) => new(
            sourceId,
            sourcePath,
            atomizerId,
            atomId,
            atom.Fingerprints,
            coverageGids.IsDefault
                ? []
                : coverageGids.Select(static gid => new DigestionCoverageEdge(gid, null))
                    .ToImmutableArray(),
            receipts ?? new DigestionReceipts([], [], null),
            new DigestionStatus(migration, truth),
            casRef ?? atom.Fingerprints.RawSha256);

    internal static string ReceiptList(string key, string value, int spaces) => value == "[]"
        ? new string(' ', spaces) + key + ": []"
        : new string(' ', spaces) + key + ":\n" + Indent(value, spaces + 2);

    private static string Indent(string value, int spaces) => string.Join(
        '\n',
        value.Split('\n').Select(line => new string(' ', spaces) + line));

    // Synthetic repositories declare their input policy explicitly, just as production does.
    internal static RepositorySnapshot Snapshot(params (string Path, byte[] Bytes)[] files)
    {
        var raw = RawRepositorySnapshot.Create(files.Select(file => new RawRepositoryEntry(file.Path, [..file.Bytes])));
        return Assert.IsType<SnapshotDecodeOutcome.Decoded>(SnapshotDecoder.Decode(raw)).Snapshot;
    }
    internal static RepositorySnapshot Snapshot(
        byte[] sourceBytes,
        IEnumerable<DigestionCasObject> casObjects) => Snapshot(
            casObjects
                .Select(static item => (item.RelativePath, item.Bytes.ToArray()))
                .Prepend(("docs/develop/theory/source.md", sourceBytes))
                .ToArray());

    internal static (string Path, byte[] Bytes) CasFile(DigestionAtom atom) =>
        (DigestionCasStore.RootPath + atom.Fingerprints.RawSha256["sha256:".Length..],
            atom.RawBytes.ToArray());

}
