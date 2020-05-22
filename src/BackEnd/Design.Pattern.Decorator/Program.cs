using Design.Pattern.Decorator.Decorators;
using Design.Pattern.Decorator.Interfaces;
using Design.Pattern.Decorator.Model;
using System;

namespace Design.Pattern.Decoratr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IOrder pizza = new Pizza("Frango", 21);
            pizza = new ExtraCover(pizza, "catupiry", 8);
            Console.WriteLine(pizza.GetLabel());
            Console.WriteLine(pizza.GetPrice());
            Console.ReadKey();
        }
    }
}
