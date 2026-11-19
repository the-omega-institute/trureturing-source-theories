.DEFAULT_GOAL := help
PROJECT := src/TheoryDigestion/TheoryDigestion.csproj
COMMANDS := ingest search-atoms show-atom atom-context migrate-atom-context source-dispatch decompose settle settle-batch settle-clear retire-sources cover cover-batch
.PHONY: help build test $(COMMANDS)

help:
	@cat README.md

build:
	dotnet build "$(PROJECT)" -c Release -p:RestoreLockedMode=true --nologo

test: build
	dotnet test tests/TheoryDigestion.Tests -c Release -p:RestoreLockedMode=true --nologo
	@python3 -m unittest discover -s tests -p 'test_*.py' -v

export SOURCE SOURCES ATOM_ID GID ATOMS REQUEST REQUESTS SELECTION TEXT STATE LIMIT DEFAULT SPLIT_AT DRY_RUN MODE WRITE SOURCE_REVISION TRUTH_BRANCH TRUTH_EXPORT SOURCE_COMMIT EXPORT_SHA256

$(COMMANDS): build
	@bash scripts/digestion.sh "$@"
