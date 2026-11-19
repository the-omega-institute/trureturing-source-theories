"""Select eligible candidates and collect occupied atom IDs from both repositories."""
import argparse
import csv
import json
import os
from pathlib import Path
import re
import subprocess
import sys
from tempfile import NamedTemporaryFile

from default_dispatch_filter import eligible_atoms

ATOM = re.compile(r"(?<![0-9a-f])[0-9a-f]{64}(?![0-9a-f])")
FILE_FIELDS = "totalCount pageInfo { hasNextPage endCursor } nodes { path }"
PULLS = """
query($owner:String!, $name:String!, $endCursor:String) {
  repository(owner:$owner, name:$name) {
    pullRequests(states:OPEN, first:25, after:$endCursor) {
      pageInfo { hasNextPage endCursor }
      nodes { number title body files(first:100) { %s } }
    }
  }
}""" % FILE_FIELDS
FILES = """
query($owner:String!, $name:String!, $number:Int!, $cursor:String!) {
  repository(owner:$owner, name:$name) {
    pullRequest(number:$number) { files(first:100, after:$cursor) { %s } }
  }
}""" % FILE_FIELDS


def pr_atoms(slug):
    owner, name = slug.split("/")
    gh = ["gh", "api", "graphql", "-f", f"owner={owner}", "-f", f"name={name}"]
    output = subprocess.check_output([*gh, "--paginate", "--slurp", "-f", f"query={PULLS}"])
    atoms = set()
    for page in json.loads(output):
        for pr in page["data"]["repository"]["pullRequests"]["nodes"]:
            atoms.update(ATOM.findall(pr["title"] + "\n" + pr["body"]))
            files = pr["files"]
            count = 0
            while True:
                for change in files["nodes"]:
                    path = change["path"]
                    if path.startswith(("Meta/Digestion/backfill/", "Meta/Digestion/atoms/sha256/")):
                        atoms.update(ATOM.findall(path))
                count += len(files["nodes"])
                if not files["pageInfo"]["hasNextPage"]:
                    break
                output = subprocess.check_output([
                    *gh, "-F", f"number={pr['number']}", "-f", f"cursor={files['pageInfo']['endCursor']}",
                    "-f", f"query={FILES}",
                ])
                files = json.loads(output)["data"]["repository"]["pullRequest"]["files"]
            if count != files["totalCount"]:
                raise ValueError(f"incomplete file list for {slug}#{pr['number']}")
    return atoms


def lease_atoms(directory):
    if not directory.is_dir():
        raise ValueError(f"invalid lease directory: {directory}")
    occupied = set()
    for path in sorted(directory.glob("lease-*.json")):
        lease = json.loads(path.read_text(encoding="utf-8"))
        rows = lease["atoms"] if isinstance(lease, dict) else lease
        if not isinstance(rows, list):
            raise ValueError(f"expected a list of leased atoms in {path}")
        for row in rows:
            atom = row["atom_id"] if isinstance(row, dict) else row
            if not isinstance(atom, str) or not ATOM.fullmatch(atom):
                raise ValueError(f"invalid leased atom in {path}")
            occupied.add(atom)
    return occupied


def flight_atoms():
    processes = subprocess.check_output(["ps", "-eo", "args"], text=True, errors="replace")
    occupied = set()
    for line in processes.splitlines():
        if "codex exec" not in line:
            continue
        for directory in re.findall(r"(/[^\s]*/consensus-rnd/sshx/[\w-]+/attempt-[0-9]+)", line):
            try:
                brief = (Path(directory) / "brief.md").read_text(encoding="utf-8")
            except FileNotFoundError:
                continue
            occupied.update(ATOM.findall(brief))
    return occupied


def source_lane_atoms(repo):
    """Read the ledger changes on published theory work branches, including pre-PR work."""
    remote = os.environ.get("SOURCE_REMOTE") or "origin"
    base = "refs/heads/" + (os.environ.get("SOURCE_BRANCH") or "dev")
    git = ["git", "-C", str(repo)]
    refs = subprocess.check_output(
        [*git, "ls-remote", "--heads", "--", remote, base, "refs/heads/lane/math/*", "refs/heads/lane/theory/*"],
        text=True,
    )
    tips = {ref: commit for commit, ref in (line.split("\t") for line in refs.splitlines())}
    if base not in tips:
        raise ValueError(f"missing source branch {base} on {remote}")
    base_commit = tips.pop(base)
    if not tips:
        return set()
    commits = sorted({*tips.values(), base_commit})
    states = subprocess.check_output(
        [*git, "cat-file", "--batch-check=%(objectname) %(objecttype)"],
        input="\n".join(commits) + "\n", text=True,
    )
    missing = [line.split()[0] for line in states.splitlines() if line.endswith(" missing")]
    if missing:
        subprocess.run([*git, "fetch", "--no-tags", "--no-write-fetch-head", "--", remote, *missing], check=True)
    occupied = set()
    for tip in sorted(set(tips.values()) - {base_commit}):
        paths = subprocess.check_output(
            [*git, "diff", "--name-only", "--no-renames", "-z", base_commit + "..." + tip,
             "--", "Meta/Digestion/backfill", "Meta/Digestion/atoms/sha256"],
        )
        occupied.update(ATOM.findall(paths.decode(errors="surrogateescape")))
    return occupied


def occupied_atoms(repo, leases):
    source_slug = os.environ.get("SOURCE_REPO") or subprocess.check_output(
        ["gh", "repo", "view", "--json", "nameWithOwner", "--jq", ".nameWithOwner"],
        cwd=repo, text=True,
    ).strip()
    main_slug = os.environ.get("MAIN_REPO") or "the-omega-institute/trureturing"
    occupied = flight_atoms()
    for slug in dict.fromkeys([source_slug, main_slug]):
        occupied.update(pr_atoms(slug))
    if leases is not None:
        occupied.update(lease_atoms(leases))
    return occupied


def pick(repo, pool, count, occupied):
    if count < 0:
        raise ValueError("count must be nonnegative")
    ranked = []
    with pool.open(encoding="utf-8", newline="") as stream:
        for row in csv.reader(stream, delimiter="\t"):
            if not row or row[0] not in {"CLEAN", "UNKNOWN"}:
                continue
            if len(row) < 5:
                raise ValueError(f"expected status, math, lines, atom_id, title in {pool}")
            _, score, size, atom, title = row[:5]
            if 60 <= int(size) <= 140 and atom not in occupied and not re.search(r"结论|总结|小结|目录|总纲", title):
                ranked.append((int(score), atom, title))
    ranked.sort(key=lambda item: -item[0])
    eligible = eligible_atoms(repo, [item[1] for item in ranked])
    selected = {}
    for _, atom, title in ranked:
        if atom in eligible:
            selected.setdefault(atom, title)
    rows = list(selected.items())[:count]
    csv.writer(sys.stdout, delimiter="\t", lineterminator="\n").writerows(rows)
    print(f"PICK_OK returned={len(rows)} taken_set={len(occupied)}", file=sys.stderr)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    sub = parser.add_subparsers(dest="command", required=True)
    exclusions = sub.add_parser("refresh-exclusions")
    exclusions.add_argument("repo", type=Path)
    exclusions.add_argument("leases", type=Path)
    exclusions.add_argument("output", type=Path)
    picker = sub.add_parser("pick")
    picker.add_argument("repo", type=Path)
    picker.add_argument("pool", type=Path)
    picker.add_argument("count", type=int)
    picker.add_argument("--leases", type=Path, default=os.environ.get("LEASE_DIR"))
    args = parser.parse_args()
    occupied = occupied_atoms(args.repo, args.leases)
    if args.command == "pick":
        occupied.update(source_lane_atoms(args.repo))
        pick(args.repo, args.pool, args.count, occupied)
    else:
        with NamedTemporaryFile("w", dir=args.output.parent, encoding="utf-8", delete=False) as stream:
            temporary = Path(stream.name)
            try:
                stream.writelines(atom + "\n" for atom in sorted(occupied))
                stream.flush()
                temporary.replace(args.output)
            finally:
                temporary.unlink(missing_ok=True)
        print(f"EXCLUSIONS_OK n={len(occupied)}")


if __name__ == "__main__":
    try:
        main()
    except (OSError, ValueError, KeyError, RuntimeError, subprocess.CalledProcessError) as error:
        sys.exit(f"SELECTION_INVALID {error}")
