using System.Collections.Generic;
using System.Threading.Tasks;
using LingoDictionary.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Linq;

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
            var database = _client.GetDatabase("lingoDictionary");
            var collection = database.GetCollection<BsonDocument>("terms");
            await collection.Find(new BsonDocument()).ForEachAsync(bson => retval.Add(new Term(bson)));
            return retval;
        }

        public async Task<Term> GetById(string id)
        {
            return null;
        }

        public Task Insert(Term term)
        {
            throw new System.NotImplementedException();
        }
    }
}