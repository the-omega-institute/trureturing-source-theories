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

## Working with a source

Install Git and the .NET 10 SDK. Run the commands in this checkout. A prose contribution can consist of the manuscript alone. To start or update its ledger, use its path on first ingestion and its source ID for queries.

```sh
make ingest SOURCE=docs/develop/theory/ACTUAL_MINIMUM_CUT_KERNEL.md
make search-atoms SOURCE=actual-minimum-cut-kernel LIMIT=5
make atom-context SOURCE=actual-minimum-cut-kernel ATOM_ID=05a3789a520a4d00402bc44d5a95ab3005d247603214c68affd604c8ac91fa7c
```

`show-atom` reads one atom. `decompose` accepts `ATOM_ID`, optional `SPLIT_AT` byte offsets and `DRY_RUN=1`. `settle`, `settle-batch` and `settle-clear` take `REQUEST`, `REQUESTS` and `ATOM_ID` respectively. Use `source-dispatch SOURCES=… DEFAULT=excluded` to opt out of automatic selection. `retire-sources SOURCES=… MODE=archive` previews retirement of a terminal source. Repeat with `WRITE=1` to apply it. Inspect the Git diff and commit the writer's output with the corresponding source change.

## Cover with a published declaration

Use the main repository’s version 2 truth export. Obtain the export and its expected SHA-256 from a trusted main-repository publication. Its transport filename can still end in `v1.json`. Supply the full source commit and the expected digest. The writer resolves the declaration within that export and requires frozen membership. The source editor checks that the hypotheses and conclusion cover the intended claim.

```sh
make cover ATOM_ID="$atom" GID="$gid" TRUTH_EXPORT="$export_file" \
  SOURCE_COMMIT="$main_commit" EXPORT_SHA256="$export_digest"
```

`make cover-batch ATOMS=rows.tsv` accepts the same evidence variables. Coverage can be added after a proof has landed. A missing publication leaves the source claim available for a later attempt.

## Source history

The initial import preserves the original Git subtrees, paths, source bytes, atom IDs and existing receipts. Pre-import commit IDs refer to the original repository. For a historical context migration, set `THEORY_LEGACY_REPOSITORY` to an existing checkout containing the requested main-repository commit. The snapshot used for the initial import is [93279cc105e](https://github.com/the-omega-institute/trureturing/tree/93279cc105e94c6a96e05298c9986beb6bf37603). The [import commit](https://github.com/the-omega-institute/trureturing-source-theories/commit/2a39da5107abbfa3a72cc883486dbc15a15994a1) records the source revision.
