namespace UrlShortener.Data.Contracts
{
    public interface IShortenedUrlsDatabaseSettings
    {
        string ShortenedUrlsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}