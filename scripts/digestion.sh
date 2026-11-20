#!/usr/bin/env bash
set -euo pipefail
set -f
command_name="$1"
args=()
add_sources() {
  local selection="${1:?a source ID or theory path is required}"
  if [[ -f "$selection" ]]; then
    args+=(--source "$selection")
  else
    local sources=()
    read -r -a sources <<< "$selection"
    for source in "${sources[@]}"; do args+=(--source "$source"); done
  fi
}
add_atom() {
  args+=(--atom-id "${ATOM_ID:?ATOM_ID is required}")
  if [[ -n "${SOURCE:-}" ]]; then args+=(--source "$SOURCE"); fi
}
case "$command_name" in
  ingest) add_sources "${SOURCE:-}" ;;
  search-atoms)
    add_sources "${SOURCE:-}"
    if [[ -n "${TEXT:-}" ]]; then args+=(--text "$TEXT"); fi
    if [[ -n "${STATE:-}" ]]; then args+=(--state "$STATE"); fi
    if [[ -n "${LIMIT:-}" ]]; then args+=(--limit "$LIMIT"); fi
    if [[ -n "${SELECTION:-}" ]]; then args+=(--selection "$SELECTION"); fi ;;
  show-atom|atom-context) add_atom ;;
  source-dispatch)
    add_sources "${SOURCES:-${SOURCE:-}}"
    if [[ -n "${DEFAULT:-}" ]]; then args+=(--default "$DEFAULT"); fi ;;
  migrate-atom-context)
    if [[ -n "${SOURCE:-}" ]]; then add_sources "$SOURCE"; else args+=(--all); fi
    if [[ -n "${ATOM_ID:-}" ]]; then args+=(--atom-id "$ATOM_ID"); fi
    if [[ -n "${SOURCE_REVISION:-}" ]]; then args+=(--source-revision "$SOURCE_REVISION"); fi
    if [[ "${WRITE:-0}" == 1 ]]; then args+=(--write); fi ;;
  decompose)
    command_name=decompose-atom
    args+=(--atom "${ATOM_ID:?ATOM_ID is required}")
    for offset in ${SPLIT_AT:-}; do args+=(--split-at "$offset"); done
    if [[ "${DRY_RUN:-0}" == 1 ]]; then args+=(--dry-run); fi ;;
  settle) command_name=settle-atom; args+=(--request "${REQUEST:?REQUEST is required}") ;;
  settle-clear) command_name=settle-atom; args+=(--clear "${ATOM_ID:?ATOM_ID is required}") ;;
  settle-context-check)
    if [[ -n "${PLAN:-}" ]]; then
      [[ -z "${REQUESTS:-}" ]] || { echo 'choose REQUESTS or PLAN' >&2; exit 2; }
      args+=(--plan "$PLAN")
      case "${ALLOW_MISSING:-0}" in
        1) args+=(--allow-missing) ;;
        0) ;;
        *) echo 'ALLOW_MISSING must be 0 or 1' >&2; exit 2 ;;
      esac
    else
      [[ "${ALLOW_MISSING:-0}" == 0 ]] || { echo 'ALLOW_MISSING requires PLAN' >&2; exit 2; }
      args+=(--requests "${REQUESTS:?REQUESTS or PLAN is required}")
    fi ;;
  settle-batch) args+=(--requests "${REQUESTS:?REQUESTS is required}") ;;
  retire-sources)
    add_sources "${SOURCES:-${SOURCE:-}}"
    args+=(--mode "${MODE:-archive}")
    case "${WRITE:-0}" in
      1) args+=(--write) ;;
      0) ;;
      *) echo 'WRITE must be 0 or 1' >&2; exit 2 ;;
    esac ;;
  cover|cover-batch|cover-gid-check)
    if [[ "$command_name" == cover ]]; then
      args+=(--cover-atom "${ATOM_ID:?ATOM_ID is required}" --gid "${GID:?GID is required}")
    else
      args+=(--atoms "${ATOMS:?ATOMS is required}")
    fi
    if [[ -n "${TRUTH_EXPORT:-}${SOURCE_COMMIT:-}${EXPORT_SHA256:-}" ]]; then
      args+=(--truth-export "${TRUTH_EXPORT:?TRUTH_EXPORT is required for export mode}" --source-commit "${SOURCE_COMMIT:?SOURCE_COMMIT is required for export mode}" --export-sha256 "${EXPORT_SHA256:?EXPORT_SHA256 is required for export mode}")
    fi
    if [[ -n "${TRUTH_BRANCH:-}" ]]; then args+=(--branch "$TRUTH_BRANCH"); fi ;;
  *) exit 64 ;;
esac
exec dotnet src/TheoryDigestion/bin/Release/net10.0/TheoryDigestion.dll "$command_name" "${args[@]}"
