using Design.Pattern.Proxy.Interfaces;
using Design.Pattern.Proxy.Model;
using System;

namespace Design.Pattern.Proxy.Repository
{
    public class ProductLogRepository : IProductLogRepository
    {
        public int Insert(Product product)
        {
            Console.WriteLine($"Produto Log inserido = id: {product.Id}, name: {product.Name}");
            return product.Id;
        }
    }
}
