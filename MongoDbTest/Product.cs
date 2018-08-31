using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest
{
    [BsonDiscriminator("product")]
    public class Product
    {
        [BsonId]
        public int StockCode { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("recommendations")]
        public List<Recommendation> Recommendations { get; set; }

        public Product(int stockCode, bool active, List<Recommendation> recommendations)
        {
            StockCode = stockCode;
            Active = active;
            Recommendations = new List<Recommendation>();
            Recommendations.AddRange(recommendations);
        }
    }
}