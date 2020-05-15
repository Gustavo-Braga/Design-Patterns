using Design.Pattern.Visitor.Element;
using Design.Pattern.Visitor.Interfaces;
using Newtonsoft.Json;
using System;

namespace Design.Pattern.Visitor.Visitor
{
    public class VisitorTransformIntoJson: IVisitor
    {
        public void VisitElement(MultiplyNumerics multiplyNumerics)
        {
            Console.WriteLine($"Resultado da multiplicação: {multiplyNumerics.Multply()}");
            Console.WriteLine(JsonConvert.SerializeObject(multiplyNumerics));
        }

        public void VisitElement(SumDecimals sumDecimals)
        {
            Console.WriteLine($"Resultado da soma: {sumDecimals.Sum()}");
            Console.WriteLine(JsonConvert.SerializeObject(sumDecimals));
        }
    }
}
