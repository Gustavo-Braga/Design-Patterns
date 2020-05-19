using Design.Pattern.Mediator.Component;
using Design.Pattern.Mediator.Mediator;
using System;

namespace Design.Pattern.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var random = new Random();

            var sumAndSubtractionMediator = new SumAndSubtractionMediator();
            var sum = new SumComponent(random.Next(-10, 100), random.Next(-10, 100), sumAndSubtractionMediator);
            var subtraction = new SubtractionComponent(random.Next(-50, 500), random.Next(-50, 500), sumAndSubtractionMediator);

            sum.Send();
            subtraction.Send();

            var multipicationAndDivisionMediator = new MultiplicationAndDivisionMediator();
            var multiplication = new MultiplicationComponent(random.Next(-20, 200), random.Next(-20, 200), multipicationAndDivisionMediator);
            var division = new DivisionComponent(random.Next(-30, 500), random.Next(-20, 600), multipicationAndDivisionMediator);

            multiplication.Send();
            division.Send();

            Console.ReadKey();
        }
    }
}
