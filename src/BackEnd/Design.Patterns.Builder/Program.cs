using Design.Patterns.Builder.Builder;
using Design.Patterns.Builder.Model;
using System;
using System.Collections.Generic;

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

            //alternativa
            var truckBuilder = new TruckBuilder()
                .SetModel("FH-420")
                .SetColor("Black")
                .SetYear(2020);

            Console.WriteLine(truckBuilder.ToString());

            truckBuilder.SetAcessories(new List<string> { "Geladeira", "Capa para bancos", "Alarme" });
            Console.WriteLine(truckBuilder.ToString());

            Console.ReadKey();
        }
    }

}
