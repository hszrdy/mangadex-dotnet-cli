using System.CommandLine;
using MangaDexDotnetCli.Api;
using MangaDexDotnetCli.Models;

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

            Argument<string> queryArgument = new Argument<string>("query");
            queryArgument.Description = "The search query for manga";


            Option<int> limitOption = new Option<int>("--limit", "-l");
            limitOption.Description = "The number of results to return";

            builtCommand.Options.Add(limitOption);
            builtCommand.Arguments.Add(queryArgument);

            builtCommand.SetAction(parseResult =>
            {
                string query = parseResult.GetRequiredValue<string>(queryArgument);
                int limit = parseResult.GetValue<int>(limitOption);
                
                Manga response = _mangaDexInstance.GetManga(query).Result;

                response.DisplayMangaInfo();

            });

            return builtCommand;
        }

    }
}