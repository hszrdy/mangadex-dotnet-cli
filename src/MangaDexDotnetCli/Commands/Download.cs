using System.CommandLine;
using MangaDexDotnetCli.Api;

namespace MangaDexDotnetCli.Commands
{
    public class Download
    {
        private MangaDexApi _mangaDexInstance;
        public Command downloadCommand { get; private set; }

        public Download(MangaDexApi mangaDexInstance)
        {
            _mangaDexInstance = mangaDexInstance;
            downloadCommand = BuildDownloadCommand();
        }

        private Command BuildDownloadCommand()
        {
            Command command = new Command("download", "Download a manga");

            Argument<string> mangaIdArgument = new Argument<string>("mangaId");
            mangaIdArgument.Description = "The ID of the manga to download";

            Option<bool> qualityOption = new Option<bool>("--datasaver", "-ds");
            qualityOption.Description = "Download the manga in datasaver quality (lower resolution)";

            command.Arguments.Add(mangaIdArgument);
            command.Options.Add(qualityOption);

            command.SetAction(parseResult =>
            {
                string mangaId = parseResult.GetRequiredValue<string>(mangaIdArgument);
                bool datasaver = parseResult.GetValue<bool>(qualityOption);

                // Placeholder logic for calling the MangaDexApi download function with the mangaId and datasaver option
                Console.WriteLine($"Downloading manga with ID: {mangaId} in {(datasaver ? "datasaver" : "standard")} quality");
            });

            return command;
        }
    }
}