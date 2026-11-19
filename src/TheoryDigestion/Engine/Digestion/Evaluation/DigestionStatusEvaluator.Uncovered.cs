using System.Collections.Immutable;

namespace StrataLint.Engine;

internal static partial class DigestionStatusEvaluator
{
    internal static DigestionLedgerEvaluation EvaluateUncovered(DigestionEvaluationScope scope,
        BackfillInventoryDocument document, RepositorySnapshot snapshot, RawChangeSet? changes = null,
        RawChangeSet? casChanges = null)
    {
        var result = EvaluateRecorded(scope, document, snapshot, changes, casChanges);
        return result with { Entries = result.Entries.Where(item => item.Entry.Coverage.IsEmpty).ToImmutableArray() };
    }

    internal static DigestionLedgerEvaluation EvaluateRecorded(
        DigestionEvaluationScope scope,
        BackfillInventoryDocument document,
        RepositorySnapshot snapshot,
        RawChangeSet? changes = null,
        RawChangeSet? casChanges = null,
        bool validateProjectedStatus = true)
    {
        ArgumentNullException.ThrowIfNull(document);
        ArgumentNullException.ThrowIfNull(snapshot);
        changes = DigestionEvaluationScopes.ResolveChanges(scope, changes);
        casChanges ??= changes;
        var entries = document.RequireDigestionEntries();
        var findings = ImmutableArray.CreateBuilder<string>();
        var duplicates = DuplicateAtomIds(entries);
        if (!duplicates.IsEmpty)
        {
            document = WithoutAtomIds(document, duplicates);
            entries = document.RequireDigestionEntries();
        }

        var alignment = DigestionLedgerAligner.Evaluate(
            document,
            snapshot,
            DigestionAlignmentMode.Projection,
            casEvaluation: DigestionCasStore.EvaluateLedgerReferences(document, snapshot, casChanges),
            changes: changes,
            casChanges: casChanges);
        findings.AddRange(alignment.Findings);
        var genreChecks = document.RequireDigestionSources()
            .ToDictionary(
                static source => source.SourceId,
                static source => source.GenreRegistryCheck,
                StringComparer.Ordinal);
        var statusAuthorityChangedAtomIds = ResolveStatusAuthorityChangedAtomIds(
            entries,
            changes,
            alignment,
            isBaseFactAffected: null);
        var work = entries
            .Select(entry => Inspect(
                entry,
                alignment.AlignmentFor(entry.AtomId),
                alignment.AtomFor(entry.AtomId),
                snapshot,
                genreChecks[entry.SourceId],
                statusAuthorityChangedAtomIds.Contains(entry.AtomId),
                findings))
            .ToArray();
        DeriveMigration(work);
        RequireDecompositionBeforeAbsorption(work, alignment.VerifiedClausePlanParents, findings);
        var evaluation = CompleteEvaluation(
            work,
            snapshot,
            findings,
            validateProjectedStatus,
            changes,
            duplicates.Select(id => $"duplicate atom_id (not judged): {id}").Order(StringComparer.Ordinal).ToImmutableArray());
        return evaluation;
    }
}
