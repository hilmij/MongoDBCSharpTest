using System;
using System.Collections.Generic;

namespace MongoDbTest
{
    public class ProductCreator
    {
        private readonly Random _random = new Random();
        private const int MaxRecomendationsCount = 5;
        public Product Create(int id, int maxProducts)
        {
            return new Product(id, _random.Next(1, 10) % 2 == 0, CreateRecommendations(maxProducts));
        }

        private List<Recommendation> CreateRecommendations(int maxProducts)
        {
            var recommendations = new List<Recommendation>();
            var recomentationCount = _random.Next(1, Math.Min(MaxRecomendationsCount, maxProducts));
            for (var i = 0; i < recomentationCount; i++)
            {
                recommendations.Add(CreateRecommendation(maxProducts));
            }

            return recommendations;
        }

        private Recommendation CreateRecommendation(int maxProducts)
        {
            return new Recommendation(_random.Next(1, maxProducts), _random.Next(1, Recommendation.MaxScore));
        }
    }
}