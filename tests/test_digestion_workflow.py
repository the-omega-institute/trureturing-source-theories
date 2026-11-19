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
