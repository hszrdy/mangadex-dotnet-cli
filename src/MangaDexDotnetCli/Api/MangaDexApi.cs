using System.Net.Http;
using System.Text.Json;

namespace MangaDexDotnetCli.Api
{
    public class MangaDexApi
    {
        private HttpClient httpClient;
        public MangaDexApi()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("mangadex-dotnet-cli");
        }
        
        public async Task<HttpResponseMessage> GetManga(string title)
        {
            try
            {
                string url = $"https://api.mangadex.org/manga?title={Uri.EscapeDataString(title)}";
                using HttpResponseMessage response = await httpClient.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching manga: {ex.Message}");
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Error occurred while fetching manga: {ex.Message}")
                };
            }
        }
    }
}