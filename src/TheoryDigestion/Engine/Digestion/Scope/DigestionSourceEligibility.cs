namespace StrataLint.Engine;

// A source is the canonical regular input, never a reader reference or an archive.
internal static class DigestionSourceEligibility
{
    private static readonly HashSet<string> ReferenceSources = ReadReferenceSources();

    private static HashSet<string> ReadReferenceSources()
    {
        using var stream = typeof(DigestionSourceEligibility).Assembly.GetManifestResourceStream("TheoryDigestion.ReferenceSources")
            ?? throw new InvalidOperationException("reference-source list is missing");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd().Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .ToHashSet(StringComparer.Ordinal);
    }

    internal static bool IsEligible(RepositorySnapshot snapshot, string path)
    {
        if (!snapshot.TryGetFile(path, out _)) return false;
        if (!snapshot.PathInventory.IsDefault
            && snapshot.PathInventory.Any(entry => entry.Path == path
                && (entry.LinkTarget is not null || entry.EffectiveMode is not ("100644" or "100755"))))
            return false;
        return IsSourcePath(path);
    }

    internal static bool IsSourcePath(string path) =>
        (path.StartsWith(DigestionOpaquePathPolicy.TheoryRootPath, StringComparison.Ordinal)
            || path.StartsWith("Library/", StringComparison.Ordinal))
        && path.EndsWith(".md", StringComparison.Ordinal) && !ReferenceSources.Contains(path);

    internal static void Require(RepositorySnapshot snapshot, string path)
    {
        if (!IsEligible(snapshot, path))
            throw new FormatException($"ineligible digestion source: {path}; a canonical eligible regular source is required");
    }
}
