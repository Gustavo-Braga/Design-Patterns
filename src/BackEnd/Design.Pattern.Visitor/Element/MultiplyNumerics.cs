using Design.Pattern.Visitor.Interfaces;

namespace Design.Pattern.Visitor.Element
{
    public class MultiplyNumerics : IElement
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        private readonly string Name = "Multipicação";

        public MultiplyNumerics(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int Multply()
        {
            return FirstNumber * SecondNumber;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitElement(this);
        }
    }
}
