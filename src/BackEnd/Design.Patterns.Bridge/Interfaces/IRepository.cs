namespace Design.Patterns.Bridge.Interfaces
{
    public interface IRepository<T>
    {
        int Insert(T entity);
    }
}
