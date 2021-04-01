using System;
using MongoDB.Bson;

namespace LingoDictionary.Models
{
    public class Term
    {
        public Term() 
        {

        }

        public Term(BsonDocument bson)
        {
            try 
            {
                Id = bson.GetValue("_id").ToString();
                Name = bson.GetValue("name").ToString();
                Definition = bson.GetValue("definition").ToString();
                Etymology = bson.GetValue("etymology").ToString();
                Example = bson.GetValue("example").ToString();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Etymology { get; set; }
        public string Example { get; set; }
    }
}