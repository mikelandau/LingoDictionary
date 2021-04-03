using MongoDB.Bson;
using MongoDB.Driver;

namespace LingoDictionary.Extensions
{
    public static class MongoClientExtensions
    {
        public static IMongoCollection<BsonDocument> GetLingoDictionaryCollection(this IMongoClient client, string collection) 
        {
            return client.GetDatabase("lingoDictionary").GetCollection<BsonDocument>(collection);
        }
    }
}