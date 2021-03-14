using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UrlShortener.Data.Entities
{
    public class ShortenedUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Url { get; set; }
    }
}