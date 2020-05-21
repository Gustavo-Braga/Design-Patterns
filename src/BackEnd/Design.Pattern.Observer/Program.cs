using Design.Pattern.Observer.Observer;
using Design.Pattern.Observer.Subject;
using System;

namespace Design.Pattern.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var random = new Random();
            var subject = new SimpleCalculator(random.Next(-20, 100), random.Next(-10, 50));

            var sum = new SumObserver();
            var multiplication = new MultiplicationObserver();

            subject.Attach(multiplication);
            subject.Attach(sum);

            subject.Attach(new DivisionObserver());
            subject.Attach(new SubtractionObserver());

            Console.WriteLine("\nExemplo sorteando os observadores");
            for (int i = 0; i < 2; i++)
            {
                subject.Operation = (Operation)random.Next(0, 3);
                subject.Notify(subject);
            }

            Console.WriteLine("\nExemplo com todos os observadores");
            for (int i = 0; i < 4; i++)
            {
                subject.Operation = (Operation)i;
                subject.Notify(subject);
            }

            subject.Detach(sum);
            subject.Detach(multiplication);

            Console.WriteLine("\nExemplo após remover os observadores de Soma e Multiplicação");
            for (int i = 0; i < 4; i++)
            {
                subject.Operation = (Operation)i;
                subject.Notify(subject);
            }

            Console.ReadKey();
        }
    }
}
