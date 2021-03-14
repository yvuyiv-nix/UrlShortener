using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Data.Entities;

namespace UrlShortener.Data.Contracts
{
    public interface IShortenedUrlsRepository
    {
        Task<ICollection<ShortenedUrl>> GetAll();

        Task<ShortenedUrl> GetUrlById(string id);

        Task<ShortenedUrl> Insert(string url);

        Task<string> GetIdByUrl(string url);
    }
}