using Design.Patterns.Bridge.Model;
using Design.Patterns.Bridge.Repository;
using System;

namespace Design.Patterns.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new Client("Gustavo", 23);
            var connectionStringSql = "connectionStringBancoRelacional";
            var sqlConnection = new SqlConnection();
            var clientRepository = new ClientRepository(connectionStringSql, sqlConnection);
            clientRepository.Insert(client);

            var product = new Product("Martelo");
            var connectionStringNoSql = "connectionStringBancoNÃORelacional";
            var noSqlConnection = new NoSqlConnection();
            var productRepository = new ProductRepository(connectionStringNoSql, noSqlConnection);
            productRepository.Insert(product);

            Console.ReadKey();
        }
    }
}
