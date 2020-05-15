namespace Design.Pattern.Visitor.Interfaces
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}
