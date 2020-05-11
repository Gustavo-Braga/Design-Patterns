using Design.Pattern.Proxy.Model;
using Design.Pattern.Proxy.Proxy;
using Design.Pattern.Proxy.Repository;
using System;

namespace Design.Pattern.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var product1 = new Product("Produto 1");

            var productRepository = new ProductRepository();
            productRepository.Insert(product1);

            var product2 = new Product("Produto 2");
            var proxyProductRepository = new ProxyProductRepository();
            proxyProductRepository.Insert(product2);

            Console.ReadKey();

        }
    }
}
