using Design.Patterns.Prototype.Model;
using System;
using System.Collections.Generic;

namespace Design.Patterns.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var developer = new Developer("Fulano", new Random().NextDouble(), new List<string> { "C#","JS" });
            var prototype = developer.CloneEmployee();
            Console.WriteLine(prototype.ToString());
            developer.Name = "Cicrano";
            Console.WriteLine(prototype.ToString());


            var prototype2 = (Developer)developer.Clone();
            Console.WriteLine(prototype2.ToString());
            prototype2.Name = "Beltrano";
            Console.WriteLine(prototype2.ToString());


            Console.ReadKey();

        }
    }
}
