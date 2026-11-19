using System.Collections.Immutable;
using System.Text;

namespace StrataLint.Engine;

internal static partial class DigestionStatusEvaluator
{

    private static void RequireDecompositionBeforeAbsorption(
        IEnumerable<EntryWork> work,
        IReadOnlySet<string> verifiedClausePlanParents,
        ImmutableArray<string>.Builder findings)
    {
        foreach (var item in work.Where(static item => item.Atom is not null && item.StatusAuthorityChanged))
        {
            if (!DigestionDecompositionPolicy.RejectsUndecomposedAbsorption(
                    item.Atom!,
                    item.Migration,
                    item.Entry.Receipts.UnresolvedSubitems.Length,
                    verifiedClausePlanParents.Contains(item.Entry.AtomId)))
            {
                continue;
            }

            findings.Add(
                $"entry {item.Entry.AtomId} has multiple clauses but claims absorbed "
                + "with unresolved_subitems=[]; decompose the uncovered clauses before absorption");
        }
    }

    internal static ImmutableHashSet<string> DuplicateAtomIds(IEnumerable<DigestionLedgerEntry> entries) =>
        entries
            .GroupBy(static entry => entry.AtomId, StringComparer.Ordinal)
            .Where(static group => group.Count() > 1)
            .Select(static group => group.Key)
            .ToImmutableHashSet(StringComparer.Ordinal);

    internal static BackfillInventoryDocument WithoutAtomIds(
        BackfillInventoryDocument document,
        IReadOnlySet<string> atomIds) =>
        document.WithDigestionSources(document.RequireDigestionSources()
            .Select(source => source with
            {
                Entries = source.Entries
                    .Where(entry => !atomIds.Contains(entry.AtomId))
                    .ToImmutableArray(),
            })
            .ToImmutableArray());

    private static DigestionLedgerEvaluation CompleteEvaluation(
        IReadOnlyList<EntryWork> work,
        RepositorySnapshot snapshot,
        ImmutableArray<string>.Builder findings,
        bool validateProjectedStatus,
        RawChangeSet? changes,
        // 非阻断的观察项(「已入库、尚未消化」)。两条评估路径共用本方法,
        // 只有 admission 路径会传入;projection 路径不产观察项。
        ImmutableArray<string> observations = default,
        ImmutableArray<DigestionContentKindObservation> contentKindObservations = default)
    {
        var evaluations = ImmutableArray.CreateBuilder<DigestionEntryEvaluation>(work.Count);
        var byId = work.ToDictionary(static item => item.Entry.AtomId, StringComparer.Ordinal);
        foreach (var item in work)
        {
            CompleteChainGaps(item, byId);
            var truth = DeriveTruth(item, snapshot, changes);
            var status = new DigestionStatus(item.Migration, truth);
            if (validateProjectedStatus
                && item.StatusAuthorityChanged
                && status != item.Entry.ProjectedStatus)
            {
                findings.Add(
                    $"entry {item.Entry.AtomId} handwritten status "
                    + $"{DigestionStatusNames.Migration(item.Entry.ProjectedStatus.Migration)}-"
                    + $"{DigestionStatusNames.Truth(item.Entry.ProjectedStatus.Truth)} differs from derived "
                    + $"{DigestionStatusNames.Migration(status.Migration)}-"
                    + DigestionStatusNames.Truth(status.Truth));
            }

            var gaps = item.Gaps
                .OrderBy(static gap => gap.Code, StringComparer.Ordinal)
                .ThenBy(static gap => gap.Detail, StringComparer.Ordinal)
                .ToImmutableArray();
            evaluations.Add(new DigestionEntryEvaluation(
                item.Entry,
                item.Alignment,
                item.Atom,
                status,
                item.Migration == DigestionMigrationState.Absorbed
                    && truth is DigestionTruthState.Closed or DigestionTruthState.Tail
                    && gaps.Length == 0,
                gaps)
            {
                StatusAuthorityChanged = item.StatusAuthorityChanged,
            });
        }

        return new DigestionLedgerEvaluation(
            evaluations.MoveToImmutable(),
            findings.Order(StringComparer.Ordinal).ToImmutableArray(),
            observations.IsDefault ? [] : observations,
            contentKindObservations.IsDefault ? [] : contentKindObservations);
    }

    private static EntryWork Inspect(
        DigestionLedgerEntry entry,
        DigestionReceiptAlignment alignment,
        DigestionAtom? atom,
        RepositorySnapshot snapshot,
        GenreRegistryCheck genreRegistryCheck,
        bool authorityChanged,
        ImmutableArray<string>.Builder findings)
    {
        var gaps = new List<DigestionGap>();
        var structured = VerifyStructuredAlignment(entry, alignment, gaps, findings);
        var nonpropositional = HasNonpropositionalReceipt(entry);
        if (entry.Receipts.Nonpropositional is not null && !nonpropositional)
            findings.Add($"entry {entry.AtomId} nonpropositional receipt is invalid or conflicts with live obligations");
        // Each recorded edge identifies the declaration checked by its original writer.
        // A partial or unresolved receipt cannot certify a terminal settlement.
        var coverage = !entry.Coverage.IsEmpty && entry.Coverage.All(edge =>
            DigestionFingerprint.IsCanonicalSha256(edge.TargetStatementId ?? string.Empty));
        var targetStates = coverage
            ? entry.Coverage.Select(edge => (edge.Gid, entry.Receipts.TailAuthorization is null ? DigestionTruthState.Closed : DigestionTruthState.Tail)).ToList()
            : [];
        if (entry.CoverageGids.Length == 0 && !nonpropositional)
        {
            gaps.Add(new DigestionGap(
                "coverage-gid-missing",
                entry.AtomId,
                DigestionGapSeverity.NonFatal));
        }


        if (entry.Receipts.UnresolvedSubitems.Length > 0)
        {
            foreach (var subitem in entry.Receipts.UnresolvedSubitems)
            {
                gaps.Add(new DigestionGap(
                    "unresolved-subitem",
                    subitem,
                    DigestionGapSeverity.NonFatal));
            }
        }

        foreach (var token in genreRegistryCheck.UnregisteredGenres)
        {
            gaps.Add(new DigestionGap(
                "unregistered-genre",
                token,
                DigestionGapSeverity.NonFatal));
        }

        var localComplete = structured
            && (nonpropositional || coverage)
            && entry.Receipts.UnresolvedSubitems.Length == 0;
        var hasProgress = nonpropositional || coverage
            || entry.Coverage.Length > 0;
        var hasUnresolvedCoverageTarget = !coverage && !entry.Coverage.IsEmpty;
        return new EntryWork(
            entry,
            alignment,
            atom,
            gaps,
            targetStates,
            localComplete,
            hasProgress,
            hasUnresolvedCoverageTarget,
            authorityChanged);
    }

    internal static bool StatusAuthorityClosureChanged(
        DigestionLedgerEntry entry,
        DigestionReceiptAlignment alignment,
        RawChangeSet? changes,
        Func<string, bool>? isBaseFactAffected)
    {
        var changedSet = changes ?? RawChangeSet.Create([]);
        if (changes is null || DigestionCasStore.EntryChanged(entry, changedSet))
        {
            return true;
        }

        bool Affected(string path) => isBaseFactAffected?.Invoke(path) ?? PathChanged(changedSet, path);

        if (alignment != DigestionReceiptAlignment.Seen && Affected(entry.SourcePath)
            || DigestionFingerprint.IsCanonicalSha256(entry.CasRef)
                && Affected(DigestionCasStore.RootPath + entry.CasRef["sha256:".Length..])
            || entry.Receipts.TailAuthorization is { } tail && Affected(tail.Path))
        {
            return true;
        }

        foreach (var gidText in entry.CoverageGids)
        {
            if (!Gid.TryParse(gidText, out var gid))
            {
                continue;
            }

            if (Affected(gid.Path.Value))
            {
                return true;
            }
        }

        return false;
    }


    private static Dictionary<string, T> UniqueByGid<T>(
        string label,
        IEnumerable<T> values,
        Func<T, string> gid,
        ImmutableArray<string>.Builder findings)
    {
        var result = new Dictionary<string, T>(StringComparer.Ordinal);
        foreach (var value in values)
        {
            var key = gid(value);
            if (!result.TryAdd(key, value))
            {
                findings.Add($"entry {label} has duplicate receipt for {key}");
            }
        }

        return result;
    }

    private static void DeriveMigration(IReadOnlyList<EntryWork> work)
    {
        foreach (var item in work)
        {
            item.Migration = HasNonpropositionalReceipt(item.Entry)
                    && item.Entry.Receipts.ChainAtoms.Length == 0
                ? DigestionMigrationState.Nonpropositional
                : item.LocalComplete && item.Entry.Receipts.ChainAtoms.Length == 0
                ? DigestionMigrationState.Absorbed
                : item.HasProgress
                    ? DigestionMigrationState.Partial
                    : DigestionMigrationState.Residual;
        }

        var byId = work.ToDictionary(static item => item.Entry.AtomId, StringComparer.Ordinal);
        var changed = true;
        while (changed)
        {
            changed = false;
            foreach (var item in work.Where(static item =>
                         !IsChainClosed(item.Migration) && item.LocalComplete))
            {
                if (item.Entry.Receipts.ChainAtoms.All(atomId =>
                        byId.TryGetValue(atomId, out var dependency)
                        && IsChainClosed(dependency.Migration)))
                {
                    item.Migration = HasNonpropositionalReceipt(item.Entry)
                        ? DigestionMigrationState.Nonpropositional : DigestionMigrationState.Absorbed;
                    changed = true;
                }
            }
        }
    }

    private static void CompleteChainGaps(
        EntryWork item,
        IReadOnlyDictionary<string, EntryWork> byId)
    {
        foreach (var atomId in item.Entry.Receipts.ChainAtoms)
        {
            if (!byId.TryGetValue(atomId, out var dependency)
                || !IsChainClosed(dependency.Migration))
            {
                item.Gaps.Add(new DigestionGap(
                    "chain-migration-incomplete",
                    atomId,
                    DigestionGapSeverity.NonFatal));
            }
        }
    }

    private static DigestionTruthState DeriveTruth(
        EntryWork item,
        RepositorySnapshot snapshot,
        RawChangeSet? changes)
    {
        if (item.Migration == DigestionMigrationState.Nonpropositional) return DigestionTruthState.Inapplicable;
        if (item.HasUnresolvedCoverageTarget
            || item.TargetStates.Count == 0
            || item.TargetStates.Any(static target => target.State is DigestionTruthState.Open or DigestionTruthState.Inapplicable))
        {
            foreach (var target in item.TargetStates.Where(static target =>
                         target.State is DigestionTruthState.Open or DigestionTruthState.Inapplicable))
            {
                item.Gaps.Add(new DigestionGap(
                    "lean-state-open",
                    $"{target.Gid}:{target.State}",
                    DigestionGapSeverity.NonFatal));
            }

            return DigestionTruthState.Open;
        }

        if (item.TargetStates.Any(static target => target.State == DigestionTruthState.Tail))
        {
            var tailGids = item.TargetStates
                .Where(static target => target.State == DigestionTruthState.Tail)
                .Select(static target => target.Gid)
                .ToArray();
            if (item.Migration != DigestionMigrationState.Absorbed
                || item.Entry.Receipts.TailAuthorization is null)
            {
                item.Gaps.Add(new DigestionGap(
                    "tail-authorization-missing",
                    string.Join(',', tailGids),
                    DigestionGapSeverity.NonFatal));
                return DigestionTruthState.Open;
            }

            var validateStoredArtifact = changes is not null
                && (DigestionCasStore.EntryChanged(item.Entry, changes)
                    || changes.Paths.Any(path => path.Value == item.Entry.Receipts.TailAuthorization.Path));
            if (!TailAuthorizationArtifact.Verify(
                    item.Entry,
                    tailGids,
                    snapshot,
                    validateStoredArtifact))
            {
                item.Gaps.Add(new DigestionGap(
                    "tail-authorization-invalid",
                    string.Join(',', tailGids),
                    DigestionGapSeverity.NonFatal));
                return DigestionTruthState.Open;
            }

            return DigestionTruthState.Tail;
        }

        return DigestionTruthState.Closed;
    }

    private static string EntryLabel(this DigestionLedgerEntry entry) => entry.AtomId;

    private sealed class EntryWork(
        DigestionLedgerEntry entry,
        DigestionReceiptAlignment alignment,
        DigestionAtom? atom,
        List<DigestionGap> gaps,
        List<(string Gid, DigestionTruthState State)> targetStates,
        bool localComplete,
        bool hasProgress,
        bool hasUnresolvedCoverageTarget,
        bool statusAuthorityChanged)
    {
        internal DigestionLedgerEntry Entry { get; } = entry;

        internal DigestionReceiptAlignment Alignment { get; } = alignment;

        internal DigestionAtom? Atom { get; } = atom;

        internal List<DigestionGap> Gaps { get; } = gaps;

        internal List<(string Gid, DigestionTruthState State)> TargetStates { get; } = targetStates;

        internal bool LocalComplete { get; } = localComplete;

        internal bool HasProgress { get; } = hasProgress;

        internal bool HasUnresolvedCoverageTarget { get; } = hasUnresolvedCoverageTarget;

        internal bool StatusAuthorityChanged { get; } = statusAuthorityChanged;

        internal DigestionMigrationState Migration { get; set; }
    }
}
