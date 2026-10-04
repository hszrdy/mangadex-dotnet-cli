using System.Net.Http;
using System.Text.Json;
using MangaDexDotnetCli.Models;

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

        public async Task<Manga> GetManga(string title)
        {
            try
            {
                string url = $"https://api.mangadex.org/manga?title={Uri.EscapeDataString(title)}";
                using HttpResponseMessage response = await httpClient.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();

                MangaResponseRaw? mangaResponse = JsonSerializer.Deserialize<MangaResponseRaw>(responseBody);
                MangaDataRaw? mangaData = mangaResponse?.data?.FirstOrDefault();

                Manga manga = new Manga(
                    mangaData?.id ?? "",
                    
                    mangaData?.attributes?.title?.GetValueOrDefault("ja-ro") ?? 
                    mangaData?.attributes?.title?.GetValueOrDefault("en") ?? "Title Unavailable",

                    mangaData?.attributes?.description?.GetValueOrDefault("en") ?? "",
                    mangaData?.attributes?.status ?? "",
                    mangaData?.attributes?.year ?? 0,
                    mangaData?.attributes?.contentRating ?? ""
                );


                Console.WriteLine($"Searching for manga with query: {title}"); 
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                return manga;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching manga: {ex.Message}");
                return new Manga("", "", "", "", 0, "");
            }
        }


        //private DTO classes to deserialize the JSON response from MangaDex API
        private class MangaAttributesRaw
        {
            public Dictionary<string, string>? title { get; set; }
            public Dictionary<string, string>? description { get; set; }
            public string? status { get; set; }
            public int? year { get; set; }
            public string? contentRating { get; set; }
        }

        private class MangaDataRaw
        {
            public string? id { get; set; }
            public MangaAttributesRaw? attributes { get; set; }
        }

        private class MangaResponseRaw
        {
            public List<MangaDataRaw>? data { get; set; }
        }
    }
}