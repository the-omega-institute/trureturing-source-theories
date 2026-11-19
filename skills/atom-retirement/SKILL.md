---
name: atom-retirement
description: Preview and retire terminal theory sources and their active digestion records.
---

# Retire a source

Inspect the selected source and its outstanding subclaims. A terminal source can be archived after its claims are covered or settled. An unresolved proposition, missing proof or incomplete child remains active.

Run `make retire-sources SOURCES="<id>" MODE=archive` to inspect the proposed change. When authorized, repeat with `WRITE=1`. Use `MODE=delete` when deletion was requested. Inspect the resulting references and Git diff. Preserve atom CAS and all surviving references. See the [command guide](../../README.md).
