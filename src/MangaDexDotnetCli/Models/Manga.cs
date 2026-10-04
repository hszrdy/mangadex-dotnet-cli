namespace MangaDexDotnetCli.Models
{
    public class Manga
    {
        public string id { get; private set;}
        public string title { get; private set;}
        public string description { get; private set;}
        public string status { get; private set;}
        public int year { get; private set;}
        public string contentRating { get; private set;}

        public Manga(string id, string title, string description, string status, int year, string contentRating)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.status = status;
            this.year = year;
            this.contentRating = contentRating;
        }

        public void DisplayMangaInfo()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"Content Rating: {contentRating}");
        }
    }
}