namespace StrataLint.TestSupport;

internal sealed class TemporaryDirectory : IDisposable
{
    public string Path { get; } = Directory.CreateTempSubdirectory("theory-digestion-").FullName;
    public void Dispose() => Directory.Delete(Path, recursive: true);
}
