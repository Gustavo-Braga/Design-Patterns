using Design.Patterns.FactoryMethod.Factory;
using System;

namespace Design.Patterns.FactoryMethod
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var factory = new TransportFactory();

            var road = factory.GetTransport(Enum.Transport.Road);
            Console.WriteLine(road.Deliver(90));

            var maritime = factory.GetTransport(Enum.Transport.Maritime);
            Console.WriteLine(maritime.Deliver(1200));

            Console.ReadKey();
        }
    }
}
