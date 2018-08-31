using System.Collections.Generic;

namespace MongoDbTest
{
    public interface IProductRepository
    {
        void Create(List<Product> products);
        List<string> Find(int stockCode);
        long Count();
    }
}