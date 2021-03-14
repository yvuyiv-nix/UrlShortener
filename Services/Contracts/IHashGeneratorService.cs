namespace UrlShortener.Services.Contracts
{
    public interface IHashGeneratorService
    {
        public string GetShortenedUrl(string input);
    }
}