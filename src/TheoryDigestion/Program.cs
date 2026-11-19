using System.Text;
using StrataLint.Cli;

if (args.Length == 0)
{
    Console.Error.WriteLine("usage: TheoryDigestion <command> [arguments]");
    return 64;
}
try
{
    var cwd = Directory.GetCurrentDirectory();
    var root = Encoding.UTF8.GetString(GitRepositoryGateway.Git(cwd, ["rev-parse", "--show-toplevel"])).TrimEnd('\r', '\n');
    Directory.SetCurrentDirectory(root);
    var repository = new GitRepositoryGateway(root);
    var rest = args[1..];
    var verb = args[0];
    var writable = verb is not ("search-atoms" or "show-atom" or "atom-context");
    var gitDir = Encoding.UTF8.GetString(GitRepositoryGateway.Git(root, ["rev-parse", "--absolute-git-dir"])).TrimEnd('\r', '\n');
    using var writer = writable
        ? new FileStream(Path.Combine(gitDir, "theory-digestion.writer"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        : null;
    var result = verb switch
    {
        "ingest" => IngestCommand.RunReportFree(root, repository, rest),
        "search-atoms" => SearchAtomsCommand.Run(repository, rest),
        "show-atom" => ShowAtomCommand.Run(repository, rest),
        "atom-context" => AtomContextCommand.Run(repository, rest),
        "migrate-atom-context" => AtomContextMigrationCommand.Run(root, repository, rest),
        "source-dispatch" => SourceDispatchCommand.Run(root, repository, rest),
        "decompose-atom" => DecomposeAtomCommand.Run(root, repository, rest),
        "settle-atom" => SettleAtomCommand.Run(root, repository, rest),
        "settle-batch" => SettleAtomCommand.RunBatch(root, repository, rest),
        "retire-sources" => RetireSourcesCommand.Run(root, repository, rest),
        "cover" or "cover-atom" or "cover-batch" => PinnedCoverCommand.Run(root, verb, rest),
        _ => new CommandResult(false, "", $"unknown command: {verb}\n", 64)
    };
    Console.Write(result.Output);
    Console.Error.Write(result.Error);
    return result.ExitCode ?? (result.Success ? 0 : 1);
}
catch (Exception error) when (error is not OutOfMemoryException)
{
    Console.Error.WriteLine(error.Message);
    return 1;
}
