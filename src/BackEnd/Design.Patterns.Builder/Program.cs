using Design.Patterns.Builder.Builder;
using Design.Patterns.Builder.Model;
using System;

namespace Design.Patterns.Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var carBuilder = new CarBuilder();
            var car = new VehicleCreator(carBuilder);
            car.CreateVehicleCaracteristics();
            Console.WriteLine(carBuilder.ToString());

            car.CreateVehicleAcessories();
            Console.WriteLine(carBuilder.ToString());

            var truckBuilder = new TruckBuilder();
            var truck = new VehicleCreator(truckBuilder);
            truck.CreateVehicleAcessories();
            Console.WriteLine(truckBuilder.ToString());

            truck.CreateVehicleCaracteristics();
            Console.WriteLine(truckBuilder.ToString());

            Console.ReadKey();
        }
    }

}
