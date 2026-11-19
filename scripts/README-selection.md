# Selecting theory atoms

Run these commands from a source-theories checkout with the source metadata, ledger and CAS available. Build the digestion CLI with `make build`. Selection also uses Python 3.12+, Git and an authenticated GitHub CLI with read access to the source and main repositories.

## Selecting from a source

```sh
scripts/atom_dedup.sh . "$source_id" "$pool"
scripts/pick_atom.sh . "$pool" 3 --leases "$lease_directory"
```

The first command compares proposition titles and self-reported Lean GIDs with D5 module and declaration names at the main checkout's `origin/dev`. It writes the existing seven-column TSV format. The four name-match outcomes are `CLEAN`, `UNKNOWN`, `HIT` and `SELF-GID`. Review the mathematical statement before assigning work. The picker rechecks current source dispatch eligibility, ranks eligible `CLEAN` and `UNKNOWN` rows by mathematical line count and emits atom ID and title. It accepts the original three positional arguments. Set `LEASE_DIR` or pass `--leases` when workers have leases.

The default main checkout is `trureturing` beside the theory repository's primary checkout. Set `TRUTH_REPOSITORY` to another local main checkout and `TRUTH_BRANCH` to select its remote-tracking branch, or set `TRUTH_REF` to a local Git reference. Fetch the desired branch in the main checkout before generating a fresh D5 comparison.

## Ranking number-theory claims

```sh
scripts/refresh_exclusions.sh . "$lease_directory" "$occupied"
scripts/prime_pick.sh . "$ranked" "$occupied"
scripts/prime_pick.sh . "$current" "$occupied" --pool "$ranked"
```

`prime_pick.sh` ranks number-theory atoms with proposition text and enough mathematical lines using the original scoring weights. It retains the nine-column TSV layout. Fresh and cached results use the digestion CLI's default-dispatch query. To filter a custom atom-and-title TSV, pipe it through `python3 scripts/default_dispatch_filter.py .`.

The exclusion snapshot combines atom IDs from the titles, descriptions and changed ledger or CAS paths of open PRs in both repositories, local running flight briefs, and the named lease directory. A lease file named `lease-*.json` can contain an array of IDs, an array of objects with `atom_id`, or an `atoms` array inside an object. For main work without ledger changes, put the source atom ID in the PR description or its lease. A shared lease directory lets independent workers see claims made before either PR opens.

The picker also excludes ledger changes on published `lane/math/*` and `lane/theory/*` branches of the source remote, including branches awaiting a PR. `SOURCE_REMOTE` and `SOURCE_BRANCH` select its remote and base branch, defaulting to `origin` and `dev`. For GitHub PR lookup, `SOURCE_REPO` defaults to the checkout's GitHub repository and `MAIN_REPO` defaults to `the-omega-institute/trureturing`. Both accept `OWNER/REPOSITORY`.
