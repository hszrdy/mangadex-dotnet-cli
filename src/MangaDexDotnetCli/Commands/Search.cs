using System.CommandLine;
using MangaDexDotnetCli.Api;

namespace MangaDexDotnetCli.Commands
{
    public class Search
    {
        private MangaDexApi  _mangaDexInstance;
        public Command searchCommand { get; private set; }

        public Search(MangaDexApi mangaDexInstance)
        {
            _mangaDexInstance = mangaDexInstance;
            searchCommand = BuildSearchCommand();
        }

        private Command BuildSearchCommand()
        {
            Command builtCommand = new Command("search", "Search for manga");

            //to be implemented

            return builtCommand;
        }

    }
}