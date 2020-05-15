using Design.Pattern.Visitor.Element;
using Design.Pattern.Visitor.Interfaces;
using System;

namespace Design.Pattern.Visitor.Visitor
{
    public class VisitorGetPropertyName : IVisitor
    {
        public void VisitElement(MultiplyNumerics multiplyNumerics)
        {
            Console.WriteLine($"Visitante {this.GetType()}, obtem {multiplyNumerics.GetType()}");
        }

        public void VisitElement(SumDecimals sumDecimals)
        {
            Console.WriteLine($"Visitante {this.GetType()}, obtem {sumDecimals.GetType()}");
        }
    }
}
