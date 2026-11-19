import json
import os
import subprocess
import tempfile
import unittest
from pathlib import Path


ROOT = Path(__file__).resolve().parents[1]
DLL = Path(os.environ.get(
    "THEORY_DIGESTION_DLL", ROOT / "src/TheoryDigestion/bin/Release/net10.0/TheoryDigestion.dll"
)).resolve()


class DigestionWorkflowTests(unittest.TestCase):
    def setUp(self):
        directory = tempfile.TemporaryDirectory()
        self.addCleanup(directory.cleanup)
        self.repo = Path(directory.name)
        subprocess.run(["git", "init", "-q"], cwd=self.repo, check=True)
        self.theory = self.repo / "docs/develop/theory"
        self.theory.mkdir(parents=True)

    def command(self, *args):
        result = subprocess.run(["dotnet", str(DLL), *args], cwd=self.repo, text=True, capture_output=True)
        self.assertEqual(result.returncode, 0, result.stderr)
        return result.stdout

    def ingest(self, name, text):
        source = self.theory / f"{name}.md"
        source.write_text(text, encoding="utf-8")
        self.command("ingest", "--source", str(source.relative_to(self.repo)))
        return self.repo / "Meta/Digestion/backfill" / name.lower()

    def test_clause_plan_decomposition_uses_recorded_source_and_cas(self):
        ledger = self.ingest("SPLIT", "**定理 18.7(链验证)**。first clause。\n\n**推论:第二子句**;the full plan has two clauses。\n")
        cas = self.repo / "Meta/Digestion/atoms/sha256"
        ids = [record.stem for record in (ledger / "residual-open").glob("*.yaml")]
        parent = max(ids, key=lambda atom: (cas / atom).stat().st_size)
        preview = self.command("decompose-atom", "--atom", parent, "--dry-run")
        applied = self.command("decompose-atom", "--atom", parent)
        self.assertIn("DECOMPOSE_SEGMENT", preview)
        self.assertIn("DECOMPOSE_SEGMENT", applied)

    def test_settlement_can_be_cleared_before_source_retirement(self):
        ledger = self.ingest("INTRO", "## Reading guide\n\nThis passage describes the chapter layout.\n")
        atom, = [record.stem for record in (ledger / "residual-open").glob("*.yaml")]
        receipt = self.repo / "receipt.toml"
        receipt.write_text(
            f'atom_id = "{atom}"\njustification = "This passage describes the chapter layout."\n'
            'previous_atom_id = "source-boundary"\nnext_atom_id = "source-boundary"\n',
            encoding="utf-8"
        )
        self.command("settle-atom", "--request", receipt.name)
        self.command("settle-atom", "--clear", atom)
        self.assertTrue((ledger / "residual-open" / f"{atom}.yaml").is_file())
        self.command("settle-atom", "--request", receipt.name)
        self.command("retire-sources", "--mode", "archive", "--source", "intro", "--write")
        self.assertTrue((self.repo / "docs/develop/archive/theory/INTRO.md").is_file())
        self.assertFalse((self.theory / "INTRO.md").exists())
        self.assertTrue((self.repo / "Meta/Digestion/atoms/sha256" / atom).is_file())

    def test_preflight_checks_every_row_and_preserves_ledger(self):
        ledger = self.ingest("DUP", "## Note\n\nSame.\n\n" * 2 + "## End\n\nLast.\n")
        cas = self.repo / "Meta/Digestion/atoms/sha256"
        repeat, = [row.stem for row in (ledger / "residual-open").glob("*.yaml")
                   if (cas / row.stem).read_text().startswith("## Note")]
        files = self.repo / "Meta"
        original = {path: path.read_bytes() for path in files.rglob("*") if path.is_file()}

        def request(atom, index=None):
            row = (f'[[requests]]\natom_id = "{atom}"\njustification = "Explanation."\n'
                   f'previous_atom_id = "source-boundary"\nnext_atom_id = "{repeat}"\n')
            return row if index is None else row + f"occurrence_index = {index}\n"

        batch = self.repo / "batch.toml"
        one = request(repeat, 1)
        batch.write_text(request(repeat) + one + one + request("f" * 64))
        result = subprocess.run(["dotnet", str(DLL), "settle-context-check", "--requests", batch.name],
                                cwd=self.repo, text=True, capture_output=True)
        self.assertEqual(result.returncode, 1, result.stderr)
        self.assertIn("record=1", result.stdout)
        self.assertIn("OCCURRENCE_INDEX_REQUIRED", result.stdout)
        self.assertIn("record=3", result.stdout)
        self.assertIn("NOT_RESIDUAL_OPEN", result.stdout)
        self.assertIn("record=4", result.stdout)
        self.assertIn("ATOM_ABSENT", result.stdout)
        self.assertIn("checked=4 skipped_missing=0 unusable=3", result.stdout)
        batch.write_text(one)
        self.assertIn("unusable=0", self.command("settle-context-check", "--requests", batch.name))
        self.assertEqual(original, {path: path.read_bytes() for path in files.rglob("*") if path.is_file()})

        plan = self.repo / "plan.json"
        plan.write_text(json.dumps({"settle": [{"atom_id": repeat}, {"atom_id": "f" * 64}]}))
        result = subprocess.run(["dotnet", str(DLL), "settle-context-check", "--plan", plan.name],
                                cwd=self.repo, text=True, capture_output=True)
        self.assertEqual(result.returncode, 1, result.stderr)
        self.assertIn("reason=multi-occurrence", result.stdout)
        self.assertIn("reason=no-blob", result.stdout)
        self.assertIn("checked=1 skipped_missing=0 unusable=2", result.stdout)
        plan.write_text(json.dumps({"settle": [{"atom_id": "f" * 64}]}))
        self.assertIn("skipped_missing=1 unusable=0",
                      self.command("settle-context-check", "--plan", plan.name, "--allow-missing"))
        self.assertEqual(original, {path: path.read_bytes() for path in files.rglob("*") if path.is_file()})
        self.assertIn("settled=1", self.command("settle-batch", "--requests", batch.name))

    def test_retire_rejects_invalid_write_flag(self):
        result = subprocess.run(["bash", str(ROOT / "scripts/digestion.sh"), "retire-sources"],
                                cwd=self.repo, env={**os.environ, "WRITE": "yes", "SOURCES": "intro"},
                                text=True, capture_output=True)
        self.assertEqual(result.returncode, 2)
        self.assertIn("WRITE must be 0 or 1", result.stderr)
