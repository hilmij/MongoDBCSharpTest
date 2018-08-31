using System;
using System.Collections.Generic;

namespace MongoDbTest
{
    class Program
    {
        private const int Count = 10000;
        private const int BatchSize = 1000;

        static void Main(string[] args)
        {
            var productRepository = new MongoDbRepository();
            var productCreator = new ProductCreator();
            var products = new List<Product>();
            for (var i = 1; i <= Count; i++)
            {
                Console.WriteLine($"Creating Product: {i}.");
                products.Add(productCreator.Create(i, Count));
                if (products.Count >= BatchSize)
                {
                    Console.WriteLine($"Inserting {products.Count} Products to Repository...");
                    productRepository.Create(products);
                    products.Clear();
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Total number of documents in repository: {productRepository.Count()}");
            Console.WriteLine();
            Console.WriteLine("Find by 10:");
            productRepository.Find(10).ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("Find by 100:");
            productRepository.Find(100).ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
