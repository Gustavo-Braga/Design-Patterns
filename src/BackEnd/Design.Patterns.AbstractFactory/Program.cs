using Design.Patterns.AbstractFactory.AbstractFactory;
using Design.Patterns.AbstractFactory.Interfaces;
using System;

namespace Design.Patterns.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var modernFurniture = new ModernFurniture();
            var modernChair1 = modernFurniture.CreateChair(true);
            var modernChair2 = modernFurniture.CreateChair();

            var modernSofa1 = modernFurniture.CreateSofa("1/2",true);
            var modernSofa2 = modernFurniture.CreateSofa();

            Console.WriteLine(modernChair1.GetType());
            Console.WriteLine(modernChair2.GetType());
            Console.WriteLine(modernSofa1.GetType());
            Console.WriteLine(modernSofa2.GetType());

            var victorianurniture = new VictorianFurniture();
            var victorianChair1 = victorianurniture.CreateChair("Couro", true);
            var victorianChair2 = victorianurniture.CreateChair();

            var victorianSofa1 = victorianurniture.CreateSofa("1/2");
            var victorianSofa2 = victorianurniture.CreateSofa();

            Console.WriteLine(victorianChair1.GetType());
            Console.WriteLine(victorianChair2.GetType());
            Console.WriteLine(victorianSofa1.GetType());
            Console.WriteLine(victorianSofa2.GetType());


            Console.ReadKey();
        }
    }
}
