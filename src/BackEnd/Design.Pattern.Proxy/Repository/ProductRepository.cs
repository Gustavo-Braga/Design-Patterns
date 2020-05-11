using Design.Pattern.Proxy.Interfaces;
using Design.Pattern.Proxy.Model;
using System;

namespace Design.Pattern.Proxy.Repository
{
    public class ProductRepository: IProductRepository
    {
        public int Insert(Product product)
        {
            product.Id = new Random().Next(1, 300);
            Console.WriteLine($"Produto inserido = id: {product.Id}, name: {product.Name}");
            return product.Id;
        }
    }
}
