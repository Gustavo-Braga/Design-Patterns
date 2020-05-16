using Design.Pattern.State.Client;
using Design.Pattern.State.State;
using System;

namespace Design.Pattern.State
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var intRandom = new Random();

            for (int i = 0; i < Enum.GetNames(typeof(Operation)).Length; i++)
            {
                var simpleCalculator = new SimpleCalculator(intRandom.Next(-2, 20), intRandom.Next(-2, 20))
                {
                    Operation = (Operation)i
                };

                switch (simpleCalculator.Operation)
                {
                    case Operation.Multiplication:
                        simpleCalculator.SetState(new MultiplicationState());
                        break;
                    case Operation.Division:
                        simpleCalculator.SetState(new DivisionState());
                        break;
                    case Operation.Subtraction:
                        simpleCalculator.SetState(new SubtractionState());
                        break;
                    case Operation.Sum:
                        simpleCalculator.SetState(new SumState());
                        break;
                }

                simpleCalculator.ExecuteState();
            }

            Console.ReadKey();
        }
    }
}
