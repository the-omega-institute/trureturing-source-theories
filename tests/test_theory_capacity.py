import subprocess
import sys
import tempfile
import unittest
from pathlib import Path


CHECK = Path(__file__).resolve().parents[1] / "scripts/theory_capacity.py"


class TheoryCapacityTests(unittest.TestCase):
    def test_only_changed_manuscripts_are_checked_with_raw_lf_count(self):
        with tempfile.TemporaryDirectory() as temp:
            root = Path(temp)
            def git(*args):
                return subprocess.check_output(["git", "-C", root, *args])
            def write(path, content):
                target = root / path
                target.parent.mkdir(parents=True, exist_ok=True)
                target.write_bytes(content)
            def commit():
                git("add", "-A")
                git("-c", "user.name=test", "-c", "user.email=test@example.org", "commit", "-qm", "fixture")
                return git("rev-parse", "HEAD").decode().strip()
            def check(base):
                return subprocess.run([sys.executable, CHECK, base], cwd=root, capture_output=True)

            git("init", "-q")
            prefix = "docs/develop/theory/"
            for name in ["untouched.md", "removed.md", "changed.Md"]:
                write(prefix + name, b"\n" * 5001)
            base = commit()
            (root / (prefix + "removed.md")).unlink()
            write(prefix + "changed.Md", b"\r\n" * 5000)
            write(prefix + "exact.md", b"\n" * 4999 + b"\xff")
            write(prefix + "empty.MD", b"")
            write("docs/develop/archive/theory/archive.md", b"\n" * 5001)
            write(prefix + "not-markdown.txt", b"\n" * 5001)
            green = commit()
            self.assertEqual(check(base).returncode, 0)

            write(prefix + "changed.Md", b"\n" * 5000 + b"\xff")
            write(prefix + "nested/file\nname.MD", b"\n" * 5001)
            # GitHub file-list cutoffs precede the changed nested manuscript.
            for index in range(3001):
                write(prefix + f"bulk/{index:04}.txt", b"changed")
            git("mv", prefix + "untouched.md", prefix + "moved.md")
            commit()
            result = check(green)
            self.assertEqual(result.returncode, 1, result.stderr)
            self.assertEqual(result.stderr.count(b"5001 lines (hard limit 5000)"), 3)
            self.assertIn(b"nested/file\nname.MD", result.stderr)
            self.assertIn(b"moved.md", result.stderr)
            self.assertIn(b"changed.Md", result.stderr)
