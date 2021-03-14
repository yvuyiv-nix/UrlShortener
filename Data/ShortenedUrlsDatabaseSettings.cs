using UrlShortener.Data.Contracts;

namespace UrlShortener.Data
{
    public class ShortenedUrlsDatabaseSettings: IShortenedUrlsDatabaseSettings
    {
        public string ShortenedUrlsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}