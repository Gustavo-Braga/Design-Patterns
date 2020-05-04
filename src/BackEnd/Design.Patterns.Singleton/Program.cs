using Design.Patterns.Singleton.Repository;
using System;

namespace Design.Patterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word");
            var repository = ProductRepository.GetInstance("Product");

            Console.ReadKey();
        }
    }
}
