using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDbTest
{
    public class MongoDbRepository : IProductRepository
    {
        private readonly IMongoDatabase _database;
        public MongoDbRepository()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            _database = client.GetDatabase("smart-subs");
        }

        public void Create(List<Product> products)
        {
            GetCollection().InsertMany(products.Select(_ => _.ToBsonDocument()));
        }

        public List<string> Find(int stockCode)
        {
            var results = new List<string>();
            GetCollection().FindSync($"{{'$or': [{{'_id': {stockCode}}}, {{'recommendations.stockCode': {stockCode}}}]}}").ForEachAsync(_ => results.Add(_.ToJson()));
            return results;
        }

        public long Count()
        {
            return GetCollection().CountDocuments(new BsonDocument());
        }

        private IMongoCollection<BsonDocument> GetCollection()
        {
            return _database.GetCollection<BsonDocument>("products");
        }
    }
}