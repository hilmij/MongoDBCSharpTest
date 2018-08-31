using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest
{
    [BsonDiscriminator("recommendation")]
    public class Recommendation
    {
        public const int MaxScore = 5;

        [BsonElement("stockCode")]
        public int StockCode { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }

        public Recommendation(int stockCode, int score)
        {
            StockCode = stockCode;
            Score = score;
        }
    }
}