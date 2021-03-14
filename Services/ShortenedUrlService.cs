using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using UrlShortener.Data.Contracts;

namespace UrlShortener.Services
{
    public class ShortenedUrlService: IShortenedUrlService
    {
        private readonly IShortenedUrlsRepository _shortenedUrlsRepository;
        
        public ShortenedUrlService(IShortenedUrlsRepository shortenedUrlsRepository)
        {
            _shortenedUrlsRepository = shortenedUrlsRepository;
        }
        
        public async Task<string> GetExistingUrlByShortenedUrl(string shortenedUrl)
        {
            if (string.IsNullOrEmpty(shortenedUrl) ||
                !ObjectId.TryParse(shortenedUrl, out var objectId))
            {
                return string.Empty;
            }

            var existingUrl = await _shortenedUrlsRepository.GetUrlById(shortenedUrl);

            return existingUrl?.Url;
        }

        public async Task<string> GetShortenedUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                return string.Empty;
            }

            var existingUrlId = await _shortenedUrlsRepository.GetIdByUrl(url);

            if (existingUrlId != null)
            {
                return existingUrlId;
            }
            
            var entity = await _shortenedUrlsRepository.Insert(url);
            return entity?.Id;
        }
    }
}