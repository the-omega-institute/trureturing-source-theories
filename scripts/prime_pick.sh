#!/usr/bin/env bash
set -euo pipefail
[ $# -ge 2 ] || { echo "PRIME_PICK_USAGE: prime_pick.sh REPO OUT.tsv [EXCLUDE.txt]" >&2; exit 64; }
[ -d "$1/.git" ] || [ -f "$1/.git" ] || { echo "PRIME_PICK_BAD_REPO=$1" >&2; exit 65; }
[ -d "$1/Meta/Digestion/backfill" ] || { echo "PRIME_PICK_NO_BACKFILL=$1" >&2; exit 66; }
[ -d "$1/Meta/Digestion/atoms/sha256" ] || { echo "PRIME_PICK_NO_CAS=$1" >&2; exit 67; }
[ $# -lt 3 ] || [ "$3" = --pool ] || [ -f "$3" ] || { echo "PRIME_PICK_BAD_EXCLUDE=$3" >&2; exit 68; }
PYTHONPATH="$(cd "$(dirname "$0")" && pwd)${PYTHONPATH:+:$PYTHONPATH}" python3 -B -X utf8 - "$@" <<'PY'
import re, sys, pathlib, csv
from default_dispatch_filter import eligible_atoms
repo, out = sys.argv[1:3]
args = sys.argv[3:]
excl_path = args.pop(0) if args and args[0] != "--pool" else None
pool = None
if args:
    if len(args) != 2 or args[0] != "--pool":
        raise SystemExit("PRIME_PICK_USAGE: expected --pool POOL.tsv")
    pool = pathlib.Path(args[1])
R = pathlib.Path(repo)
cas = R / "Meta/Digestion/atoms/sha256"

excluded = set()
if excl_path:
    excluded = {l.strip() for l in open(excl_path, encoding="utf-8") if l.strip()}

KW = re.compile(r'素数|prime|Prime|zeta|Zeta|Dirichlet|Legendre|Jacobi|同余|CRT|中国剩余|'
                r'Fibonacci|Zeckendorf|Galois|单位群|类群|Frobenius|二次剩余|欧拉|Euler|'
                r'Mobius|Möbius|Mertens|Mangoldt|Chebyshev|孪生|twin|因子|divisor|整除')
PROP = re.compile(r'定理|命题|引理|推论')
MATHCMD = re.compile(r'\\[A-Za-z]{2,}')
GOOD = re.compile(r'因为|由于|所以|因此|取|令|存在素数|构造|反例|有限|恰好|唯一|介值|不动点|'
                  r'置换|归纳|计数|余数|同余|整除|奇偶')
HEAVY = re.compile(r'RH|Riemann|解析延拓|测度|分布|Weil|trace formula|谱|算子|Hilbert|Banach|'
                   r'渐近|Mertens|素数定理|积分|收敛半径|全纯|亚纯')
PROOF = re.compile(r'###\s*证明|证明[:：]|∎')

scanned = 0
rows = []
for vol in ([] if pool else sorted((R / "Meta/Digestion/backfill").iterdir())):
    ro = vol / "residual-open"
    if not ro.is_dir():
        continue
    for y in sorted(ro.glob("*.yaml")):
        scanned += 1
        if y.stem in excluded:
            continue
        f = cas / y.stem
        if not f.is_file():
            continue
        text = f.read_text(errors="replace")
        lines = text.splitlines()
        if not (12 <= len(lines) <= 130):
            continue
        title = lines[0].strip()
        if not re.match(r'^#+\s', title):
            continue
        if not PROP.search(title + text[:400]):
            continue
        if not KW.search(text):
            continue
        math = sum(1 for l in lines if '$' in l or MATHCMD.search(l))
        if math < 5:
            continue
        good = len(GOOD.findall(text))
        heavy = len(HEAVY.findall(text))
        proof = 1 if PROOF.search(text) else 0
        rows.append((good * 2 + proof * 6 - heavy * 3, good, heavy, proof,
                     math, len(lines), y.stem, vol.name, title[:70]))

if pool:
    with pool.open(encoding="utf-8", newline="") as fh:
        cached = csv.reader(fh, delimiter="\t")
        if next(cached, None) != ["score", "good", "heavy", "proof", "math", "lines", "atom_id", "source_id", "title"]:
            raise SystemExit("PRIME_PICK_INVALID_POOL")
        for row in cached:
            if len(row) != 9:
                raise SystemExit("PRIME_PICK_INVALID_POOL")
            scanned += 1
            if row[6] not in excluded:
                rows.append(tuple(map(int, row[:6])) + tuple(row[6:]))
eligible = eligible_atoms(R, [row[6] for row in rows])
rows = [row for row in rows if row[6] in eligible]
rows.sort(key=lambda r: (-r[0], -r[4]))
with open(out, "w", encoding="utf-8") as fh:
    fh.write("score\tgood\theavy\tproof\tmath\tlines\tatom_id\tsource_id\ttitle\n")
    writer = csv.writer(fh, delimiter="\t", lineterminator="\n")
    for r in rows:
        writer.writerow(r)
print(f"PRIME_PICK_OK ranked={len(rows)} scanned={scanned} excluded={len(excluded)}")
PY
