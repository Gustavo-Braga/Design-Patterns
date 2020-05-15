using Design.Pattern.Visitor.Element;
using Design.Pattern.Visitor.Interfaces;
using Design.Pattern.Visitor.Visitor;
using System;
using System.Collections.Generic;

namespace Design.Pattern.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new List<IElement>
            {
                new MultiplyNumerics(20,30),
                new SumDecimals(53.42M,43.99M)
            };

            var transformIntoJson = new VisitorTransformIntoJson();
            foreach (var item in client)
                item.Accept(transformIntoJson);

            var getPropertyName = new VisitorGetPropertyName();
            foreach (var item in client)
                item.Accept(getPropertyName);

            Console.ReadKey();
        }
    }
}
