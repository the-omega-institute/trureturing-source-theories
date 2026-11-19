using System.Text;
using System.Text.Json;
using StrataLint.Engine;

namespace StrataLint.Cli;

internal static partial class SettleAtomCommand
{
    // Legacy plans contain atom IDs, before the writer's neighbor or occurrence choices.
    internal static CommandResult CheckLegacyPlan(string root, IRepositoryGateway repository, IReadOnlyList<string> args)
    {
        if (args is not ["--plan", _] and not ["--plan", _, "--allow-missing"])
            return new(false, "", "USAGE: settle-context-check --plan FILE [--allow-missing]\n", 2);
        try
        {
            using var document = JsonDocument.Parse(ReadRequest(root, args[1]).AsMemory());
            if (document.RootElement.ValueKind != JsonValueKind.Object
                || !document.RootElement.TryGetProperty("settle", out var rows) || rows.ValueKind != JsonValueKind.Array)
                throw new FormatException("expected a settle array");
            var output = new StringBuilder();
            int record = 0, skipped = 0, unusable = 0, checkedAtoms = 0;
            foreach (var row in rows.EnumerateArray())
            {
                record++;
                var id = row.ValueKind == JsonValueKind.Object && row.TryGetProperty("atom_id", out var field)
                    && field.ValueKind == JsonValueKind.String ? field.GetString() : null;
                try
                {
                    if (id is null || !DigestionNonpropositional.IsAtomId(id))
                        throw new FormatException("invalid atom_id");
                    var cas = DigestionQuerySelection.Literal(DigestionCasStore.RootPath + id);
                    if (repository.SearchCurrentPaths([cas]).Count == 0)
                    {
                        if (args.Count == 3)
                        {
                            skipped++;
                            continue;
                        }
                        throw new FormatException("no-blob");
                    }
                    checkedAtoms++;
                    var (_, snapshot, ledger) = DigestionQuerySelection.ReadContext(repository, id, null, out var atomized);
                    var contexts = DigestionAtomContextProjection.ResolveOccurrences(snapshot, ledger, id, atomized);
                    if (contexts.Length > 1) throw new FormatException("multi-occurrence");
                }
                catch (Exception error) when (error is not OutOfMemoryException)
                {
                    unusable++;
                    var reason = error is DigestionAtomContextException context ? context.Code.ToString() : error.Message;
                    var label = id is not null && DigestionNonpropositional.IsAtomId(id) ? id : "invalid";
                    output.Append($"SETTLE_UNUSABLE atom_id={label} reason={reason} record={record}\n");
                }
            }
            output.Append($"SETTLE_CONTEXT_CHECK checked={checkedAtoms} skipped_missing={skipped} unusable={unusable}\n");
            return new(unusable == 0, output.ToString(), "");
        }
        catch (Exception error) when (error is not OutOfMemoryException)
        {
            return new(false, "", $"SETTLE_PLAN_INVALID {error.Message}\n", 2);
        }
    }
}
