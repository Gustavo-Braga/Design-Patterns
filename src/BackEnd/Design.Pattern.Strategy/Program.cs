using Design.Pattern.Strategy.Context;
using Design.Pattern.Strategy.Strategy;
using System;

namespace Design.Pattern.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var random = new Random();
            var firstNumber = random.Next(-10, 30);
            var secondNumber = random.Next(-20, 40);

            var context = new CalculatorContext();

            context
                .SetStrategy(new SumStrategy(firstNumber, secondNumber))
                .SetStrategy(new SubtractionStrategy(firstNumber, secondNumber))
                .SetStrategy(new MultiplicationStrategy(firstNumber, secondNumber))
                .SetStrategy(new DivisionStrategy(firstNumber, secondNumber));

            foreach (var item in context.Execute())
                Console.WriteLine(item);


            Console.ReadKey();
        }
    }
}
