import hashlib
import json
import os
import subprocess
import tempfile
import unittest
from pathlib import Path


REPO = Path(__file__).resolve().parents[1]
DLL = Path(os.environ.get("THEORY_DIGESTION_DLL", REPO / "src/TheoryDigestion/bin/Release/net10.0/TheoryDigestion.dll")).resolve()
COMMIT = "a" * 40
GID = "D5/S1/Words/Identity.example"


def digest(data):
    return "sha256:" + hashlib.sha256(data).hexdigest()


def export_bytes(*, status="frozen", names=("ns(n0,7:example)",), statement="2", commit=COMMIT):
    node = {
        "repo_path": "D5/S1/Words/Identity.lean",
        "freeze_status": status,
        "frozen_node_id": "sha256:" + "1" * 64,
        "declarations": [{"declaration_name_key": name, "kind": "theorem", "statement_id": "sha256:" + statement * 64} for name in sorted(names)],
        "node_axiom_closure": [],
        "prerequisite_frozen_node_ids": [],
    }
    model = {"dialect": "stratalint.truth-export.v2", "producer": "TruthExportCommand", "schema": "stratalint.truth-export",
             "source_commit": commit, "source_tree": "b" * 40, "schema_version": 2, "nodes": [node]}
    return (json.dumps(model, sort_keys=True) + "\n").encode()


class PinnedCoverTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        subprocess.run(["git", "init", "-q"], cwd=self.root, check=True)
        source = self.root / "docs/develop/theory/EXAMPLE.md"
        source.parent.mkdir(parents=True)
        source.write_text("# Example\n\nA concrete proposition.\n")
        self.cli("ingest", "--source", "docs/develop/theory/EXAMPLE.md")
        self.entries = sorted(self.root.glob("Meta/Digestion/backfill/*/residual-open/*.yaml"))
        self.assertGreaterEqual(len(self.entries), 1)
        self.atom = self.entries[0].stem

    def cli(self, *args, ok=True):
        proc = subprocess.run(["dotnet", str(DLL), *args], cwd=self.root, text=True, capture_output=True)
        if ok:
            self.assertEqual(proc.returncode, 0, proc.stderr + proc.stdout)
        else:
            self.assertNotEqual(proc.returncode, 0, proc.stdout)
        return proc

    def evidence(self, data=None, pin=None, commit=COMMIT):
        data = data if data is not None else export_bytes()
        path = self.root / "export.json"
        path.write_bytes(data)
        return ["--truth-export", str(path), "--source-commit", commit, "--export-sha256", pin or digest(data)]

    def test_cover_retries_and_pinned_statement_conflict(self):
        args = ["cover", "--cover-atom", self.atom, "--gid", GID]
        self.assertIn("ledger_changed=true", self.cli(*args, *self.evidence()).stdout)
        closed = self.entries[0].parent.parent / "absorbed-closed" / self.entries[0].name
        old = closed.read_bytes()
        self.assertIn(f"source_commit: {COMMIT}".encode(), old)
        self.assertIn(f"truth_export_sha256: {digest(export_bytes())}".encode(), old)
        self.assertIn("ledger_changed=false", self.cli(*args, *self.evidence()).stdout)
        self.assertIn("coverage-target-mismatch", self.cli(*args, *self.evidence(export_bytes(statement="3")), ok=False).stderr)
        self.assertEqual(closed.read_bytes(), old)
        changed_export = export_bytes(names=("ns(n0,7:example)", "ns(n0,5:extra)"))
        self.assertIn("conflicting exports", self.cli(*args, *self.evidence(changed_export), ok=False).stderr)
        self.assertEqual(closed.read_bytes(), old)

    def test_legacy_receipt_is_pinned_only_on_explicit_cover(self):
        old = self.entries[0]
        closed = old.parent.parent / "absorbed-closed" / old.name
        closed.parent.mkdir(exist_ok=True)
        text = old.read_text().replace("coverage_gids: []",
            f"coverage_gids:\n  - gid: {GID}\n    target_statement_id: sha256:{'2' * 64}")
        old.unlink()
        closed.write_text(text)
        args = ["cover", "--cover-atom", self.atom, "--gid", GID]
        self.cli(*args, *self.evidence(export_bytes(statement="3")), ok=False)
        self.assertEqual(closed.read_text(), text)
        self.assertIn("ledger_changed=true", self.cli(*args, *self.evidence()).stdout)
        self.assertIn("ledger_changed=false", self.cli(*args, *self.evidence()).stdout)

    def test_unresolved_receipt_preserves_open_state(self):
        entry = self.entries[0]
        text = entry.read_text().replace("unresolved_subitems: []", "unresolved_subitems:\n    - remaining claim")
        entry.write_text(text)
        self.cli("cover", "--cover-atom", self.atom, "--gid", GID, *self.evidence(), ok=False)
        self.assertEqual(entry.read_text(), text)
        self.assertFalse((entry.parent.parent / "absorbed-closed" / entry.name).exists())

    def test_evidence_rejected_before_mutation(self):
        args = ["cover", "--cover-atom", self.atom, "--gid", GID]
        old = self.entries[0].read_bytes()
        for expected, evidence in [
            ("digest", dict(pin="sha256:" + "f"*64)),
            ("commit", dict(commit="e"*40)),
            ("unfrozen", dict(data=export_bytes(status="proven-not-yet-frozen"))),
            ("ambiguous", dict(data=export_bytes(names=("ns(ns(n0,1:A),7:example)", "ns(ns(n0,1:B),7:example)")))),
            ("absent", dict(data=export_bytes(names=("ns(n0,4:else)",)))),
            ("invalid", dict(data=export_bytes(names=("ns(n0,4:name)x",)))),
        ]:
            with self.subTest(expected):
                self.assertIn(expected, self.cli(*args, *self.evidence(**evidence), ok=False).stderr)
                self.assertEqual(self.entries[0].read_bytes(), old)
        self.assertTrue(self.cli(*args, *self.evidence(), ok=True).stdout)

    def test_gid_check_resolves_each_distinct_selector_without_accessing_the_ledger(self):
        table = self.root / "batch.tsv"
        missing = "D5/S1/Words/Identity.unknown"
        other = "D5/S1/Words/Missing.example"
        table.write_text("".join(f"{self.atom}\t{gid}\n" for gid in [GID, missing, GID, other]))
        (self.root / "Meta").rename(self.root / "saved-ledger")
        (self.root / ".git/theory-digestion.writer").unlink()
        evidence = self.evidence()
        args = ["cover-gid-check", "--atoms", table.name, *evidence]
        output = self.cli(*args, ok=False).stdout.splitlines()
        self.assertEqual(output.count(f"OK {GID}"), 1)
        self.assertTrue(any(line.startswith(f"BAD {missing} ") for line in output))
        self.assertTrue(any(line.startswith(f"BAD {other} ") for line in output))
        table.write_text(f"{self.atom}\t{GID}\n")
        self.assertEqual(self.cli(*args).stdout.strip(), f"OK {GID}")
        self.assertFalse((self.root / "Meta").exists())
        self.assertFalse((self.root / ".git/theory-digestion.writer").exists())

    def test_batch_groups_duplicates_and_retains_original_pin(self):
        path = self.root / "batch.tsv"
        path.write_text((self.atom + "\t" + GID + "\n") * 2)
        batch = ["cover-batch", "--atoms", str(path)]
        line = self.cli(*batch, *self.evidence()).stdout
        self.assertEqual(json.loads(line.removeprefix("COVER_BATCH "))["lines"], [1, 2])
        self.assertIn("already_applied", self.cli(*batch, *self.evidence()).stdout)
        closed = self.entries[0].parent.parent / "absorbed-closed" / self.entries[0].name
        before = closed.read_bytes()
        new_commit = "c" * 40
        result = self.cli(*batch, *self.evidence(export_bytes(commit=new_commit), commit=new_commit))
        self.assertIn("already_applied", result.stdout)
        self.assertEqual(closed.read_bytes(), before)


if __name__ == "__main__":
    unittest.main()
