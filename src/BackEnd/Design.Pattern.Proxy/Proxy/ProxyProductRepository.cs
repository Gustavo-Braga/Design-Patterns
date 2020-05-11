using Design.Pattern.Proxy.Interfaces;
using Design.Pattern.Proxy.Model;
using Design.Pattern.Proxy.Repository;
using System;

namespace Design.Pattern.Proxy.Proxy
{
    public class ProxyProductRepository : IProductRepository
    {
        public IProductLogRepository _productLogRepository = new ProductLogRepository();
        public IProductRepository _productRepository = new ProductRepository();


        public int Insert(Product product)
        {
            Console.WriteLine("Iniciando proxy");
            product.Id = _productRepository.Insert(product);

            _productLogRepository.Insert(product);
            Console.WriteLine("Finalizando proxy");
            return product.Id;
        }
    }
}
