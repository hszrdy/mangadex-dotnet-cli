using System.CommandLine;

namespace MangaDexDotnetCli
{
    class Program
    {
        static void Main(string[] args)
        {

            RootCommand rootCommand = new("Sample command-line app");

            Option<string> nameOption = new("--name", "-n")
            {
                Description = "Your name"
            };

            rootCommand.Options.Add(nameOption);

            rootCommand.SetAction(parseResult =>
            {
                string name = parseResult.GetValue(nameOption);
                Console.WriteLine($"Hello, {name ?? "World"}!");
            });

            rootCommand.Parse(args).Invoke();
        }
    }
}
