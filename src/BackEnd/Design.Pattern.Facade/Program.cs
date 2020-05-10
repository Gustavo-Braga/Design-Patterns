using Design.Pattern.Facade.Facade;
using System;

namespace Design.Pattern.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var facade = new CarFacade();
            facade.CreateCompleteCar();
            Console.ReadKey();
        }
    }
}
