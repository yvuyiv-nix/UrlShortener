using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using UrlShortener.Data.Contracts;
using UrlShortener.Data.Entities;

namespace UrlShortener.Data
{
    public class ShortenedUrlsRepository: IShortenedUrlsRepository
    {
        private readonly IMongoCollection<ShortenedUrl> _shortenedUrls;
        
        public ShortenedUrlsRepository(IShortenedUrlsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shortenedUrls = database.GetCollection<ShortenedUrl>(settings.ShortenedUrlsCollectionName);
        }
        
        public async Task<ICollection<ShortenedUrl>> GetAll()
        {
            var list = await _shortenedUrls.FindAsync(x => true);
            return list.ToList();
        }

        public async Task<ShortenedUrl> GetUrlById(string id)
        {
            var entity = await _shortenedUrls.FindAsync(x => x.Id == id);
            return entity.FirstOrDefault();
        }

        public async Task<string> GetIdByUrl(string url)
        {
            var result = await _shortenedUrls.FindAsync(x => x.Url == url);

            var entity = result.FirstOrDefault();

            return entity?.Id;
        }

        public async Task<ShortenedUrl> Insert(string url)
        {
            var entityToInsert = new ShortenedUrl
            {
                Url = url
            };
            
            await _shortenedUrls.InsertOneAsync(entityToInsert);

            return entityToInsert;
        }
    }
}