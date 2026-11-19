"""Check the line limit for added and modified theory manuscripts between Git revisions."""
import argparse
import os
import subprocess
import sys


LIMIT = 5000
THEORY_ROOT = "docs/develop/theory/"


def changed_documents(base, head):
    # A rename has the same manuscript destination as a deletion plus an addition.
    raw = subprocess.check_output([
        "git", "diff", "--raw", "--no-abbrev", "--no-renames", "--no-ext-diff",
        "--diff-filter=AMT", "-z", base, head, "--", THEORY_ROOT,
    ])
    fields = iter(raw.split(b"\0"))
    for header in fields:
        if not header:
            break
        path = next(fields)
        if path.lower().endswith(b".md"):
            _, mode, _, blob, _ = header.split()
            if mode in (b"100644", b"100755", b"120000"):
                yield os.fsdecode(path), blob


def check(base, head):
    ok = True
    for path, blob in changed_documents(base, head):
        content = subprocess.check_output(["git", "cat-file", "blob", blob])
        lines = content.count(b"\n") + int(bool(content) and not content.endswith(b"\n"))
        if lines > LIMIT:
            print(f"{path}: theory document spans {lines} lines (hard limit {LIMIT}); "
                  "continue in a separate volume and preserve existing entries and references", file=sys.stderr)
            ok = False
    return ok


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("base")
    parser.add_argument("head", nargs="?", default="HEAD")
    args = parser.parse_args()
    raise SystemExit(0 if check(args.base, args.head) else 1)
