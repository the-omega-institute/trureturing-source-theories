using System.Collections.Immutable;
using Dunet;

namespace StrataLint.Engine;

public enum RawChangeKind
{
    Added,
    Modified,
    Deleted,
    Copied,
}

public sealed record RawChange(RepoPath Path, RawChangeKind Kind);

public sealed class RawChangeSet
{
    private readonly HashSet<string> exactPaths;

    private RawChangeSet(
        ImmutableArray<RawChange> entries,
        HashSet<string> exactPaths)
    {
        Entries = entries;
        Paths = entries.Select(static entry => entry.Path).ToImmutableArray();
        this.exactPaths = exactPaths;
    }

    public ImmutableArray<RawChange> Entries { get; }

    public ImmutableArray<RepoPath> Paths { get; }

    public bool ContainsPath(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        return exactPaths.Contains(path);
    }

    public static RawChangeSet Create(IEnumerable<string> paths) =>
        CreateWithKinds(paths.Select(static path => (path, RawChangeKind.Modified)));

    public static RawChangeSet CreateWithKinds(
        IEnumerable<(string Path, RawChangeKind Kind)> entries)
    {
        ArgumentNullException.ThrowIfNull(entries);
        var builder = ImmutableArray.CreateBuilder<RawChange>();
        var exact = new HashSet<string>(StringComparer.Ordinal);
        var folded = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var (rawPath, kind) in entries)
        {
            if (!RepoPath.TryCreate(rawPath, out var path))
            {
                throw new ArgumentException($"Invalid raw changed path: {rawPath}", nameof(entries));
            }

            if (!exact.Add(path.Value) || !folded.Add(path.Value))
            {
                throw new ArgumentException(
                    $"Duplicate or case-colliding changed path: {path.Value}",
                    nameof(entries));
            }

            builder.Add(new RawChange(path, kind));
        }

        return new RawChangeSet(builder.ToImmutable(), exact);
    }
}
