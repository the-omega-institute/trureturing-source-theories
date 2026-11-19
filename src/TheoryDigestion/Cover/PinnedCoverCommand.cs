using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using StrataLint.Engine;

namespace StrataLint.Cli;

internal static partial class PinnedCoverCommand
{
    internal static CommandResult Run(string root, string verb, IReadOnlyList<string> args)
    {
        try
        {
            var evidence = new Dictionary<string, string>(StringComparer.Ordinal);
            var options = new List<string>();
            for (int i = 0; i < args.Count; i += 2)
            {
                if (i + 1 == args.Count || string.IsNullOrWhiteSpace(args[i + 1]))
                    throw new FormatException($"missing {args[i]} value");
                if (args[i] is "--truth-export" or "--source-commit" or "--export-sha256")
                {
                    if (!evidence.TryAdd(args[i], args[i + 1])) throw new FormatException($"duplicate {args[i]}");
                }
                else
                {
                    options.Add(args[i]);
                    options.Add(args[i + 1]);
                }
            }
            if (evidence.Count != 3)
                throw new FormatException("supply --truth-export FILE --source-commit COMMIT --export-sha256 sha256:HEX");
            var batch = verb == "cover-batch";
            var items = batch ? Parse(root, options).Items : ImmutableArray.Create(Single(options));
            var export = new PinnedTruthExport(Path.GetFullPath(evidence["--truth-export"], root),
                evidence["--source-commit"], evidence["--export-sha256"]);
            var repository = new GitRepositoryGateway(root);
            if (!batch)
            {
                var changed = Apply(root, repository, items[0], export);
                return new(true, $"COVER atom_id={items[0].AtomId} ledger_changed={changed.ToString().ToLowerInvariant()}\n", "");
            }
            var selected = DigestionQuerySelection.ReadAtoms(repository, items.Select(item => item.AtomId).ToArray());
            var chains = DigestionQuerySelection.ReadChains(repository, selected, allowMissing: true);
            return RunBatch(root, repository, Plan(items, chains.Document), export);
        }
        catch (Exception e) when (e is not OutOfMemoryException)
        {
            return new(false, "", $"COVER_INVALID {e.Message}\n", 1);
        }
    }

    private static BatchItem Single(IReadOnlyList<string> args)
    {
        string? atom = null;
        var gids = ImmutableArray.CreateBuilder<string>();
        for (int i = 0; i < args.Count; i += 2)
        {
            if (args[i] is "--cover-atom" or "--atom-id" && atom is null) atom = args[i + 1];
            else if (args[i] == "--gid" && !gids.Contains(args[i + 1])) gids.Add(args[i + 1]);
            else throw new FormatException($"unknown or duplicate option: {args[i]} {args[i+1]}");
        }
        if (atom is null || !DigestionNonpropositional.IsAtomId(atom) || gids.Count == 0)
            throw new FormatException("cover requires --cover-atom ATOM_ID --gid DECLARATION_GID");
        return new(atom, gids.ToImmutable(), []);
    }

    private static CommandResult RunBatch(string root, IRepositoryGateway repository, BatchPlan plan, PinnedTruthExport export)
    {
        var failed = new HashSet<string>(StringComparer.Ordinal);
        var output = new StringBuilder();
        foreach (var atom in plan.Order)
        {
            var blocked = plan.Children[atom].FirstOrDefault(failed.Contains);
            if (blocked is not null) failed.Add(atom);
            if (!plan.Items.TryGetValue(atom, out var item)) continue;
            var status = "blocked";
            var reason = $"dependency failed: {blocked}";
            if (blocked is null)
            {
                try
                {
                    var changed = Apply(root, repository, item, export);
                    status = changed ? "applied" : "already_applied";
                    reason = changed ? "coverage committed" : "coverage bindings validated";
                }
                catch (Exception e) when (e is FormatException or InvalidOperationException)
                {
                    failed.Add(atom);
                    status = "failed";
                    reason = e.Message;
                }
            }
            output.Append("COVER_BATCH ").AppendLine(JsonSerializer.Serialize(new { atom_id = atom, status, lines = item.Lines, reason }));
        }
        return new(failed.Count == 0, output.ToString(), "", failed.Count == 0 ? 0 : 1);
    }

    private static bool Apply(string root, IRepositoryGateway repository, BatchItem item, PinnedTruthExport export)
    {
        var edges = item.Gids.Select(export.Resolve).ToArray();
        var selected = DigestionQuerySelection.ReadAtom(repository, item.AtomId);
        var matches = selected.Document.RequireDigestionEntries().Where(entry => entry.AtomId == item.AtomId).ToArray();
        if (matches.Length != 1) throw new FormatException($"expected one ledger entry for {item.AtomId}, found {matches.Length}");
        var target = matches[0];
        if (target.Coverage.IsEmpty && target.ProjectedStatus.Truth != DigestionTruthState.Open)
            throw new FormatException($"atom {item.AtomId} has no open residual");
        var coverage = target.Coverage.ToDictionary(edge => edge.Gid, StringComparer.Ordinal);
        var changed = false;
        foreach (var edge in edges)
        {
            if (coverage.TryGetValue(edge.Gid, out var previous))
            {
                if (previous.TargetStatementId != edge.TargetStatementId)
                    throw new FormatException($"coverage-target-mismatch: {edge.Gid}");
                if (previous.SourceCommit == edge.SourceCommit && previous.TruthExportSha256 != edge.TruthExportSha256)
                    throw new FormatException($"conflicting exports for pinned commit {edge.SourceCommit}: {edge.Gid}");
                if (previous.SourceCommit is not null) continue;
            }
            coverage[edge.Gid] = edge;
            changed = true;
        }
        if (!changed) return false;

        var chain = DigestionQuerySelection.ReadChains(repository, selected, [item.AtomId]);
        var entries = chain.Document.RequireDigestionEntries();
        var inputPaths = entries.SelectMany(entry => new[] { entry.SourcePath, entry.Receipts.TailAuthorization?.Path })
            .OfType<string>().Distinct().Select(DigestionQuerySelection.Literal).ToArray();
        var inputs = DigestionQuerySelection.Load(DigestionQuerySelection.Merge(chain.Raw, repository.ReadCurrent(inputPaths)));
        if (!inputs.Snapshot.TryGetFile(DigestionQuerySelection.CasPath(target), out var blob)
            || DigestionFingerprint.Compute(blob.RawBytes.AsSpan()) != target.Fingerprints
            || target.CasRef != "sha256:" + item.AtomId)
            throw new FormatException($"missing or inconsistent atom bytes: {item.AtomId}");
        var covered = target with
        {
            Coverage = coverage.Values.OrderBy(edge => edge.Gid, StringComparer.Ordinal).ToImmutableArray(),
            Receipts = target.Receipts with { CoverDisposition = null },
        };
        var planned = Replace(inputs.Document, covered);
        var evaluated = DigestionStatusEvaluator.EvaluateRecorded(DigestionEvaluationScope.FullScan, planned, inputs.Snapshot,
            validateProjectedStatus: false);
        IngestCommand.RequireNoReceiptIntegrityFailure(evaluated);
        var result = evaluated.Entries.Single(entry => entry.Entry.AtomId == item.AtomId);
        if (target.Coverage.IsEmpty && (!result.Deletable || result.DerivedStatus.Truth != DigestionTruthState.Closed))
            throw new FormatException($"atom {item.AtomId} retains gaps: " + string.Join(',', result.Gaps.Select(gap => gap.Code)));
        if (!target.Coverage.IsEmpty)
        {
            var before = DigestionStatusEvaluator.EvaluateRecorded(DigestionEvaluationScope.FullScan, inputs.Document, inputs.Snapshot)
                .Entries.Single(entry => entry.Entry.AtomId == item.AtomId);
            if (result.DerivedStatus.Migration < before.DerivedStatus.Migration
                || TruthRank(result.DerivedStatus.Truth) < TruthRank(before.DerivedStatus.Truth)
                || result.Gaps.Except(before.Gaps).Any())
                throw new FormatException($"coverage regresses existing obligations on {item.AtomId}");
        }
        var final = Replace(planned, covered with { ProjectedStatus = result.DerivedStatus });
        var raw = IngestCommand.ReplaceLedger(inputs.Raw, inputs.Document, final);
        var updates = IngestCommand.LedgerUpdates(inputs.Raw, raw, inputs.Document, final);
        IngestCommand.ApplyLedgerUpdatesAtomically(root, inputs.Raw, updates, requireInputsUnchanged: () =>
        {
            var paths = inputs.Raw.Entries.Select(entry => entry.Path).Concat(updates.Select(update => update.Path))
                .Distinct(StringComparer.Ordinal).Select(DigestionQuerySelection.Literal).ToArray();
            var actual = repository.ReadCurrent(paths).Entries.ToDictionary(entry => entry.Path, StringComparer.Ordinal);
            if (actual.Count != inputs.Raw.Entries.Length || inputs.Raw.Entries.Any(entry =>
                !actual.TryGetValue(entry.Path, out var current) || !current.Bytes.AsSpan().SequenceEqual(entry.Bytes.AsSpan())))
                throw new IOException($"coverage inputs changed before publication: {item.AtomId}");
        });
        return !updates.IsEmpty;
    }

    private static int TruthRank(DigestionTruthState truth) => truth switch
    {
        DigestionTruthState.Open => 0,
        DigestionTruthState.Tail => 1,
        DigestionTruthState.Closed => 2,
        _ => throw new FormatException("inapplicable receipt cannot acquire coverage"),
    };

    private static BackfillInventoryDocument Replace(BackfillInventoryDocument doc, DigestionLedgerEntry replacement) =>
        doc.WithDigestionSources(doc.RequireDigestionSources().Select(source => source with
        {
            Entries = source.Entries.Select(entry => entry.AtomId == replacement.AtomId ? replacement : entry).ToImmutableArray(),
        }).ToImmutableArray());
}
