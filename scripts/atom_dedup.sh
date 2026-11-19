#!/usr/bin/env bash
set -euo pipefail
[ $# -eq 3 ] || { echo "DEDUP_USAGE: atom_dedup.sh REPO VOLUME OUT.tsv" >&2; exit 64; }
[ -d "$1/.git" ] || [ -f "$1/.git" ] || { echo "DEDUP_BAD_REPO=$1" >&2; exit 65; }
[ -d "$1/Meta/Digestion/backfill/$2/residual-open" ] || { echo "DEDUP_BAD_VOLUME=$2" >&2; exit 66; }
python3 -X utf8 - "$@" <<'PY'
import csv, os, re, sys, pathlib, subprocess
repo, volume, out = sys.argv[1:4]
R = pathlib.Path(repo).resolve()
if volume in (".", "..") or pathlib.Path(volume).name != volume:
    raise SystemExit("DEDUP_BAD_VOLUME")
common = subprocess.check_output(["git", "-C", R, "rev-parse", "--path-format=absolute", "--git-common-dir"], text=True).strip()
main = os.environ.get("TRUTH_REPOSITORY", str(pathlib.Path(common).parent.parent / "trureturing"))
ref = os.environ.get("TRUTH_REF") or "origin/" + (os.environ.get("TRUTH_BRANCH") or "dev")
git = ["git", "-C", main]
commit = subprocess.check_output([*git, "rev-parse", "--verify", "--end-of-options", ref + "^{commit}"], text=True).strip()
paths = subprocess.check_output([*git, "ls-tree", "-rz", "--name-only", commit, "--", "D5"]).split(b"\0")
names = [pathlib.Path(os.fsdecode(p)).stem for p in paths if p.endswith(b".lean")]
if not names:
    raise SystemExit("DEDUP_EMPTY_D5")
prefix = r"^(theorem|lemma|def|structure|abbrev|instance|noncomputable def)[[:space:]]+"
matches = subprocess.run([*git, "grep", "-IhE", prefix, commit, "--", ":(glob)D5/**/*.lean"],
                         stdout=subprocess.PIPE)
if matches.returncode not in (0, 1):
    raise SystemExit(matches.returncode)
decl = re.compile(r"^(?:theorem|lemma|def|structure|abbrev|instance|noncomputable def)\s+([A-Za-z_][A-Za-z0-9_']*)")
for line in matches.stdout.decode(errors="replace").splitlines():
    match = decl.match(line)
    if match:
        names.append(match[1])
corpus = "\n".join(names).lower()

STOP = {"the","of","and","for","with","theorem","criterion","existence","lemma","principle",
        "property","condition","form","case","type","general","exact","local","global","new",
        "law","rule","test","value","map","set","one","two","all","non","via","under","from"}
PROP = re.compile(r'定理|命题|引理|推论|定义')
MATHCMD = re.compile(r'\\[A-Za-z]{2,}')
SELFGID = re.compile(r'^Lean GID.*?\n+`([^`]+)`', re.M | re.S)

cas = R / "Meta/Digestion/atoms/sha256"
rows = []
for y in sorted((R / "Meta/Digestion/backfill" / volume / "residual-open").glob("*.yaml")):
    f = cas / y.stem
    if not f.is_file(): continue
    txt = f.read_text(errors="replace"); lines = txt.splitlines()
    if len(lines) < 12: continue                      # 截断/碎片 atom (见 #4410)
    title = lines[0].strip()
    if not re.match(r'^#+\s', title): continue        # 无标题者非独立命题单元
    if not (PROP.search(title) or PROP.search(txt)): continue
    math = sum(1 for l in lines if ('$' in l or MATHCMD.search(l)))
    if math < 6: continue
    _gid = SELFGID.search(txt)
    if _gid:
        rows.append(("SELF-GID", math, len(lines), y.stem, title[:80], "", _gid.group(1)[:60]))
        continue
    kws = [w.lower() for w in re.findall(r'[A-Za-z][A-Za-z\-]{2,}', title)
           if w.lower() not in STOP and len(w) >= 4]
    if not kws:                                       # 无 ASCII 括注 => 本器无查重键
        rows.append(("UNKNOWN", math, len(lines), y.stem, title[:80], "", ""))
        continue
    def _hit(w):
        return w in corpus or (('-' in w) and w.replace('-', '') in corpus)
    hits = [w for w in kws if _hit(w)]
    rows.append(("HIT" if hits else "CLEAN", math, len(lines), y.stem, title[:80],
                 ",".join(kws), ",".join(hits)))

rows.sort(key=lambda r: ({"CLEAN":0,"UNKNOWN":1,"HIT":2,"SELF-GID":3}[r[0]], -r[1]))
with open(out, "w", encoding="utf-8") as fh:
    fh.write("status\tmath\tlines\tatom_id\ttitle\tkeywords\thits\n")
    csv.writer(fh, delimiter="\t", lineterminator="\n").writerows(rows)
n = {k: sum(1 for r in rows if r[0] == k)
     for k in ("CLEAN", "UNKNOWN", "HIT", "SELF-GID")}
print(f"DEDUP_OK clean={n['CLEAN']} unknown={n['UNKNOWN']} hit={n['HIT']} "
      f"self_gid={n['SELF-GID']} corpus_names={len(names)} volume={volume}")
PY
