using System.CommandLine;

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

            RootCommand rootCommand = new("MangaDexDotnetCli");


            Command searchCommand = new("search", "Search for manga");

            Option<string> option = new Option<string>("--query", "-q");
            option.Description = "The search query for manga";

            Option<int> limitOption = new Option<int>("--limit", "-l");
            limitOption.Description = "The number of results to return";

            searchCommand.Options.Add(option);
            searchCommand.Options.Add(limitOption);

            Option<string> nameOption = new("--name", "-n")
            {
                Description = "Your name"
            };

            rootCommand.Options.Add(nameOption);
            rootCommand.Subcommands.Add(searchCommand);

            rootCommand.SetAction(parseResult =>
            {
                string name = parseResult.GetValue(nameOption);
                Console.WriteLine($"Hello, {name ?? "World"}!");
            });

            searchCommand.SetAction( parseResult =>
            {
                string query = parseResult.GetValue<string>(option);
                int limit = parseResult.GetValue<int>(limitOption);

                // Call your search function here with the query and limit
                Console.WriteLine($"Searching for manga with query: {query} and limit: {limit}");
            });

            rootCommand.Parse(args).Invoke();
        }
    }
}
