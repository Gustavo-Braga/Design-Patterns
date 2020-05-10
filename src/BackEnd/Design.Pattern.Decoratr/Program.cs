using Design.Pattern.Decoratr.Decorators;
using Design.Pattern.Decoratr.Interfaces;
using Design.Pattern.Decoratr.Model;
using System;

namespace Design.Pattern.Decoratr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IOrder pizza = new Pizza("Frango", 21);
            pizza = new ExtraCover(pizza, "borda recheada", 8);
            Console.WriteLine(pizza.GetLabel());
            Console.WriteLine(pizza.GetPrice());
            Console.ReadKey();
        }
    }
}
