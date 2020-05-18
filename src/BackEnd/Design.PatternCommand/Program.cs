using Design.Pattern.Command.Command;
using Design.Pattern.Command.Receiver;
using System;

namespace Design.Pattern.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var random = new Random();
            var simpleCalculator = new SimpleCalculator(random.Next(-5, 30), random.Next(-5, 30));
            var invoke = new InvokerCommand()
                .SetCommand(new SumCommand(simpleCalculator))
                .SetCommand(new DivisionCommand(simpleCalculator))
                .SetCommand(new SubtractionCommand(simpleCalculator))
                .SetCommand(new MultiplicationCommand(simpleCalculator));

            Console.WriteLine("Executa operações");
            invoke.Execute();


            Console.ReadKey();
        }
    }
}
