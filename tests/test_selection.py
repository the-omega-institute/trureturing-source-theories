import csv
from hashlib import sha256
import json
import io
import os
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[1]
SCRIPTS = ROOT / "scripts"
sys.path.insert(0, str(SCRIPTS))
import selection

DLL = Path(os.environ.get("THEORY_DIGESTION_DLL", ROOT / "src/TheoryDigestion/bin/Release/net10.0/TheoryDigestion.dll")).resolve()


class SelectionTests(unittest.TestCase):
    def setUp(self):
        directory = tempfile.TemporaryDirectory()
        self.addCleanup(directory.cleanup)
        self.repo = Path(directory.name)
        subprocess.run(["git", "init", "-q"], cwd=self.repo, check=True)
        self.env = dict(os.environ, THEORY_DIGESTION_DLL=str(DLL))

    def run_command(self, *args):
        result = subprocess.run(args, cwd=self.repo, env=self.env, text=True, capture_output=True)
        self.assertEqual(result.returncode, 0, result.stderr)
        return result.stdout

    def source(self, name, keyword):
        title = f"## 定理 1（{keyword}）"
        content = title + "\n" + "".join(f"$x_{{{i}}}$ 因为构造存在素数\n" for i in range(64))
        atom = sha256(content.encode()).hexdigest()
        cas = self.repo / "Meta/Digestion/atoms/sha256"
        cas.mkdir(parents=True, exist_ok=True)
        (cas / atom).write_text(content)
        ledger = self.repo / "Meta/Digestion/backfill" / name
        (ledger / "residual-open").mkdir(parents=True)
        (ledger / "residual-open" / f"{atom}.yaml").write_text("")
        (ledger / "source.toml").write_text(
            f'source_id = "{name}"\npath = "docs/develop/theory/{name}.md"\natomizer = "generic-v1"\n'
            'genre_registry_check = "no-registry"\nunregistered_genres = []\n'
        )
        return atom

    def test_default_dispatch_for_fresh_cached_and_dedup_pools(self):
        available = self.source("one", "SearchablePrime")
        other = self.source("two", "AnotherPrime")
        pool = self.repo / "ranked.tsv"
        command = [SCRIPTS / "prime_pick.sh", self.repo, pool]
        self.assertIn("ranked=2", self.run_command(*command))
        self.run_command("dotnet", DLL, "source-dispatch", "--source", "two", "--default", "excluded")
        available_pool = self.repo / "eligible.tsv"
        self.assertIn("ranked=1", self.run_command(*command[:2], available_pool))
        self.assertIn("ranked=1", self.run_command(*command[:2], available_pool, "--pool", pool))
        with available_pool.open() as stream:
            self.assertEqual([available], [r["atom_id"] for r in csv.DictReader(stream, delimiter="\t")])

        main = self.repo / "main"
        main.mkdir()
        self.run_command("git", "-C", main, "init", "-q")
        (main / "D5").mkdir()
        (main / "D5/Result.lean").write_text("theorem SearchablePrime := True\n")
        self.run_command("git", "-C", main, "add", "D5")
        self.run_command("git", "-C", main, "-c", "user.email=test@example.com", "-c", "user.name=test", "commit", "-qm", "D5 names")
        self.env.update(TRUTH_REPOSITORY=str(main), TRUTH_REF="HEAD")
        dedup = self.repo / "dedup.tsv"
        self.assertIn("hit=1", self.run_command(SCRIPTS / "atom_dedup.sh", self.repo, "one", dedup))

        # The saved picker pool is rechecked with the production CLI even after selection was disabled.
        pick_pool = self.repo / "pool.tsv"
        pick_pool.write_text(f"CLEAN\t99\t65\t{other}\tother\nUNKNOWN\t65\t65\t{available}\tone\n")
        with patch.dict(os.environ, self.env), patch("sys.stdout", new_callable=io.StringIO) as output:
            selection.pick(self.repo, pick_pool, 2, set())
        self.assertEqual(f"{available}\tone\n", output.getvalue())

    def test_source_lane_excludes_claim_before_pull_request_opens(self):
        atom = "b" * 64
        self.run_command("git", "checkout", "-qb", "dev")
        self.run_command("git", "-c", "user.email=test@example.com", "-c", "user.name=test",
                         "commit", "-q", "--allow-empty", "-m", "base")
        self.run_command("git", "checkout", "-qb", "lane/theory/work")
        entry = self.repo / "Meta/Digestion/backfill/book/residual-open" / f"{atom}.yaml"
        entry.parent.mkdir(parents=True)
        entry.write_text("atom")
        self.run_command("git", "add", "Meta")
        self.run_command("git", "-c", "user.email=test@example.com", "-c", "user.name=test",
                         "commit", "-qm", "select source")
        with tempfile.TemporaryDirectory() as directory:
            self.run_command("git", "clone", "-q", "--single-branch", "--branch", "dev",
                             "--no-local", self.repo, directory)
            self.assertEqual({atom}, selection.source_lane_atoms(directory))

    def test_both_repository_pr_pages_and_lease_formats(self):
        atoms = [f"{i:064x}" for i in range(1, 6)]
        def response(args):
            if "name=main" in args:
                nodes = [dict(number=7, title="task", body=f"ATOM_ID={atoms[0]}", files=dict(
                    totalCount=2, pageInfo=dict(hasNextPage=True, endCursor="next"),
                    nodes=[dict(path=f"Meta/Digestion/backfill/book/residual-open/{atoms[1]}.yaml")],
                ))]
                if "--paginate" not in args:
                    return json.dumps(dict(data=dict(repository=dict(pullRequest=dict(files=dict(
                        totalCount=2, pageInfo=dict(hasNextPage=False),
                        nodes=[dict(path=f"Meta/Digestion/backfill/book/residual-open/{atoms[2]}.yaml")],
                    ))))))
            else:
                self.assertIn("name=source", args)
                nodes = [dict(number=8, title=atoms[3], body="", files=dict(totalCount=0, pageInfo=dict(hasNextPage=False), nodes=[]))]
            return json.dumps([dict(data=dict(repository=dict(pullRequests=dict(nodes=nodes))))])
        (self.repo / "lease-one.json").write_text(json.dumps(dict(atoms=[dict(atom_id=atoms[4])])))
        (self.repo / "lease-two.json").write_text(json.dumps([atoms[4]]))
        with patch.dict(os.environ, SOURCE_REPO="org/source", MAIN_REPO="org/main"), patch.object(
            selection.subprocess, "check_output", side_effect=response
        ), patch.object(selection, "flight_atoms", return_value=set()):
            self.assertEqual(set(atoms), selection.occupied_atoms(self.repo, self.repo))
