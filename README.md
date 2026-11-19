# Theory sources

This repository owns theory manuscripts and the working record of their digestion into claims. Lean declarations, proofs, Blueprint and frozen membership are maintained in [trureturing](https://github.com/the-omega-institute/trureturing).

| Path | Contents |
| --- | --- |
| `docs/develop/theory/` | Current manuscripts |
| `docs/develop/archive/theory/` | Retired manuscripts |
| `Meta/Digestion/atoms/sha256/` | Original content-addressed atom bytes |
| `Meta/Digestion/backfill/` | Source metadata, context pointers, outstanding claims, coverage and settlement |
| `Library/` | Source-byte snapshots for registered literature inputs, taken from the main repository |
| `src/TheoryDigestion/` | Intake, queries and ledger writers |

[Read theory manuscripts and literature notes together](https://the-omega-institute.github.io/trureturing-source-theories/). The reader follows references across both repositories.

## Working with a source

Install Git and the .NET 10 SDK. Run the commands in this checkout. A prose contribution can consist of the manuscript alone. To start or update its ledger, use its path on first ingestion and its source ID for queries.

```sh
make ingest SOURCE=docs/develop/theory/ACTUAL_MINIMUM_CUT_KERNEL.md
make search-atoms SOURCE=actual-minimum-cut-kernel LIMIT=5
make atom-context SOURCE=actual-minimum-cut-kernel ATOM_ID=05a3789a520a4d00402bc44d5a95ab3005d247603214c68affd604c8ac91fa7c
```

`show-atom` reads one atom. `decompose` accepts `ATOM_ID`, optional `SPLIT_AT` byte offsets and `DRY_RUN=1`. `settle`, `settle-batch` and `settle-clear` take `REQUEST`, `REQUESTS` and `ATOM_ID` respectively. Use `source-dispatch SOURCES=… DEFAULT=excluded` to opt out of automatic selection. `retire-sources SOURCES=… MODE=archive` previews retirement of a terminal source. Repeat with `WRITE=1` to apply it. Inspect the Git diff and commit the writer's output with the corresponding source change.

## Check a settlement batch

Run `make settle-context-check REQUESTS=rows.toml` to preview the same ordered `[[requests]]` input as `make settle-batch`. The preview evaluates each row against the preceding successful rows in memory. It reports every unusable row with its record number, verifies neighbor IDs and the selected occurrence, and exits nonzero when any row fails. Apply the batch with `make settle-batch REQUESTS=rows.toml`.

For an older JSON plan containing a `settle` array of objects with `atom_id`, use `make settle-context-check PLAN=plan.json`. This checks that each atom has a single resolvable occurrence. A repeated occurrence needs an explicit `occurrence_index` in the TOML request. Set `ALLOW_MISSING=1` with a JSON plan to skip absent atom blobs.

## Cover with a frozen declaration

`make cover` resolves the main trureturing repository’s `dev` branch and reads the requested module’s frozen state at that commit. The selector must identify one declaration in the module. A batch resolves the branch once and shares each module’s state across its rows. The source editor checks that the declaration’s hypotheses and conclusion cover the claim.

```sh
make cover ATOM_ID="$atom" GID="$gid"
make cover-batch ATOMS=rows.tsv
```

Set `TRUTH_BRANCH` to follow a different main-repository branch. Each branch receipt records the branch, the observed commit, the module statement ID, the SHA-256 of the frozen state and the declaration name key. The declaration-level statement ID is available from a verified truth export. Repeating a cover while the module’s frozen state is identical preserves the existing receipt across unrelated branch updates.

For offline use or a release-specific declaration ID, supply all three export arguments. Use a trusted version 2 truth export and its published digest. The transport filename can end in `v1.json`.

```sh
make cover ATOM_ID="$atom" GID="$gid" TRUTH_EXPORT="$export_file" \
  SOURCE_COMMIT="$main_commit" EXPORT_SHA256="$export_digest"
```

## Source history

The initial import preserves the original Git subtrees, paths, source bytes, atom IDs and existing receipts. Pre-import commit IDs refer to the original repository. For a historical context migration, set `THEORY_LEGACY_REPOSITORY` to an existing checkout containing the requested main-repository commit. The snapshot used for the initial import is [93279cc105e](https://github.com/the-omega-institute/trureturing/tree/93279cc105e94c6a96e05298c9986beb6bf37603). The [import commit](https://github.com/the-omega-institute/trureturing-source-theories/commit/2a39da5107abbfa3a72cc883486dbc15a15994a1) records the source revision.

The `theory-required` check runs the capacity check on changed manuscripts and runs digestion tests when the runtime, scripts, tests or their workflow change.
