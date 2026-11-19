using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using StrataLint.Engine;

namespace StrataLint.Cli;

internal interface IRepositoryGateway
{
    RawRepositorySnapshot ReadCurrent(IReadOnlyList<string> paths);
    IReadOnlyList<string> SearchCurrentPaths(IReadOnlyList<string> paths);
    RawRepositorySnapshot ReadRevision(string revision, IReadOnlyList<string> paths);
}

internal sealed class GitRepositoryGateway(string root) : IRepositoryGateway
{
    internal static byte[] Git(string directory, IReadOnlyList<string> arguments)
    {
        var start = new ProcessStartInfo("git")
        {
            WorkingDirectory = directory, RedirectStandardOutput = true,
            RedirectStandardError = true, UseShellExecute = false
        };
        foreach (var arg in arguments) start.ArgumentList.Add(arg);
        using var process = Process.Start(start) ?? throw new IOException("git failed to start");
        using var output = new MemoryStream();
        var err = process.StandardError.ReadToEndAsync();
        process.StandardOutput.BaseStream.CopyTo(output);
        process.WaitForExit();
        if (process.ExitCode != 0) throw new IOException(err.GetAwaiter().GetResult().Trim());
        return output.ToArray();
    }

    public IReadOnlyList<string> SearchCurrentPaths(IReadOnlyList<string> paths)
    {
        var results = new HashSet<string>(StringComparer.Ordinal);
        var queries = new List<string>();
        foreach (var selection in paths.Distinct(StringComparer.Ordinal))
        {
            if (selection.StartsWith(":(glob)", StringComparison.Ordinal))
            {
                queries.Add(selection);
                continue;
            }

            var path = selection.StartsWith(":(literal)", StringComparison.Ordinal) ? selection[10..] : selection;
            if (!RepoPath.TryCreate(path, out _)) throw new FormatException($"invalid repository path: {path}");
            var absolute = RegularPath(root, path);
            if (File.Exists(absolute)) results.Add(path);
            else if (Directory.Exists(absolute)) queries.Add(":(literal)" + path);
        }
        foreach (var chunk in queries.Chunk(256))
        {
            var listed = Git(root, ["ls-files", "--cached", "--others", "--exclude-standard", "-z", "--", ..chunk]);
            foreach (var path in Encoding.UTF8.GetString(listed).Split('\0', StringSplitOptions.RemoveEmptyEntries))
                if (File.Exists(Path.Combine(root, path))) results.Add(path);
        }
        return results.Order(StringComparer.Ordinal).ToArray();
    }

    internal static string RegularPath(string root, string path)
    {
        if (!RepoPath.TryCreate(path, out _) || path.Split('/').Any(part => part.Equals(".git", StringComparison.OrdinalIgnoreCase)))
            throw new IOException($"invalid repository path: {path}");
        var current = root;
        foreach (var part in path.Split('/'))
        {
            current = Path.Combine(current, part);
            if (new FileInfo(current).LinkTarget is not null) throw new IOException($"symlink in repository path: {path}");
        }
        return current;
    }

    public RawRepositorySnapshot ReadCurrent(IReadOnlyList<string> paths) =>
        RawRepositorySnapshot.Create(SearchCurrentPaths(paths).Select(path =>
        {
            return new RawRepositoryEntry(path, File.ReadAllBytes(RegularPath(root, path)).ToImmutableArray());
        }));

    public RawRepositorySnapshot ReadRevision(string revision, IReadOnlyList<string> paths)
    {
        if (revision.Length != 40 || revision.Any(c => !char.IsAsciiHexDigit(c)))
            throw new FormatException("source revision must be a full Git commit");
        var history = root;
        try { Git(root, ["cat-file", "-e", revision + "^{commit}"]); }
        catch (IOException) when (Environment.GetEnvironmentVariable("THEORY_LEGACY_REPOSITORY") is { } legacy)
        { history = Path.GetFullPath(legacy); }
        return RawRepositorySnapshot.Create(paths.Select(selection =>
        {
            var path = selection.StartsWith(":(literal)", StringComparison.Ordinal) ? selection[10..] : selection;
            if (!RepoPath.TryCreate(path, out _) || !DigestionSourceEligibility.IsSourcePath(path))
                throw new FormatException($"invalid historical source path: {path}");
            return new RawRepositoryEntry(path, Git(history, ["show", revision + ":" + path]).ToImmutableArray());
        }));
    }

    internal static bool MatchesPathSelection(string path, string selection) =>
        selection.StartsWith(":(literal)", StringComparison.Ordinal)
            ? path == selection[10..] || path.StartsWith(selection[10..] + "/", StringComparison.Ordinal)
            : selection.StartsWith(":(glob)", StringComparison.Ordinal)
                ? FileMapGlob.CreateForAdmissionPlane(selection[7..]).IsMatch(path)
                : path == selection || path.StartsWith(selection + "/", StringComparison.Ordinal);
}
