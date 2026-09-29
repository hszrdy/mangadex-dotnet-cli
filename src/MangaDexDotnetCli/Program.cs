using System.CommandLine;
using MangaDexDotnetCli.Api;
using MangaDexDotnetCli.Commands;

namespace MangaDexDotnetCli
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Skeleton of a CommandLine call in CLI:
            rootCommand subCommand --option1 value1 --option2 value2
            rootCOmmand --option1 value1 --option2 value2
            */

            MangaDexApi mangaDexInstance = new MangaDexApi();
            Search searchInstance = new Search(mangaDexInstance);

            RootCommand rootCommand = new("MangaDexDotnetCli");

            rootCommand.Subcommands.Add(searchInstance.searchCommand);

            rootCommand.Parse(args).Invoke();
        }
    }
}
