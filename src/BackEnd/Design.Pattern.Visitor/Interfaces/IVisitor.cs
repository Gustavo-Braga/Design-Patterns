using Design.Pattern.Visitor.Element;

namespace Design.Pattern.Visitor.Interfaces
{
    public interface IVisitor
    {
        void VisitElement(MultiplyNumerics multiplyNumerics);
        void VisitElement(SumDecimals sumDecimals);
    }
}
