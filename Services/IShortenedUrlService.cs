using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public interface IShortenedUrlService
    {
        Task<string> GetExistingUrlByShortenedUrl(string shortenedUrl);

        Task<string> GetShortenedUrl(string url);
    }
}