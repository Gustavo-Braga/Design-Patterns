namespace Design.Pattern.Iterator.Interfaces
{
    public interface IAggregate
    {
        IIterator CreateIterator();
    }
}
