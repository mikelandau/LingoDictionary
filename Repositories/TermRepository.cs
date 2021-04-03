using System.Collections.Generic;
using System.Threading.Tasks;
using LingoDictionary.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Linq;
using LingoDictionary.Extensions;

namespace LingoDictionary.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly IMongoClient _client;

        public TermRepository(IMongoClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<Term>> GetAll()
        {
            var retval = new List<Term>();
            var collection = _client.GetLingoDictionaryCollection("terms");
            await collection.Find(new BsonDocument()).ForEachAsync(bson => retval.Add(new Term(bson)));
            return retval;
        }

        public async Task<Term> GetById(string id)
        {
            var collection = _client.GetLingoDictionaryCollection("terms");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            if (result == null)
                return null;
            return new Term(result);
        }

        public async Task Insert(Term term)
        {
            var document = new BsonDocument
            {
                { "name", term.Name },
                { "definition", term.Definition },
                { "etymology", term.Etymology },
                { "example", term.Example}
            };
            var collection = _client.GetLingoDictionaryCollection("terms");
            await collection.InsertOneAsync(document);
        }
    }
}