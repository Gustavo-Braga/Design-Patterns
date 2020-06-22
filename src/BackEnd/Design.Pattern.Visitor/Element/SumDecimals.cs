using Design.Pattern.Visitor.Interfaces;

namespace Design.Pattern.Visitor.Element
{
    public class SumDecimals : IElement
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }

        public SumDecimals(decimal firstNumber, decimal secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public decimal Sum()
        {
            return FirstNumber + SecondNumber;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitElement(this);
        }
    }
}
