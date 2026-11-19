---
name: codex-theory-ingest
description: Ingest a theory manuscript and locate its resulting claims in the source theories repository.
---

# Ingest a theory

Preserve the author's exact text, provenance and license. Place an independently authored manuscript under `docs/develop/theory/`. Follow the [writing skill](../theory-volume-template/SKILL.md) for new material. An author can publish prose before requesting ingestion.

1. Run `make ingest SOURCE=<path>`. Use a committed source ID for subsequent updates.
2. Run `make search-atoms SOURCE=<id>` to find the affected records and `make atom-context SOURCE=<id> ATOM_ID=<id>` to inspect source wording, hypotheses and neighbors.
3. Inspect and commit the source and writer-produced changes. Retain unfinished propositions in the active ledger. Use `make cover ATOM_ID=… GID=…` to record a declaration frozen on the main repository’s `dev` branch. Set `TRUTH_BRANCH` to select another branch. The [README](../../README.md) describes the optional offline export input.

When the task calls for a new proof, supply the main-repository contributor with the exact statement and this repository's source, atom and revision. The proof can be published independently.
