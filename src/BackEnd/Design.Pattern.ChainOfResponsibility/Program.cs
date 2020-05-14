using Design.Pattern.ChainOfResponsibility.Handler;
using System;

namespace Design.Pattern.ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var handler = new EvenNumber()
                .Next(new OddNumber()
                .Next(new GreaterThanAThousand()));

            for (int i = 0; i < 3; i++)
            {
                handler.Execute(new Random().Next(0,9999));
            }


            Console.ReadKey();
        }
    }
}
