namespace Design.Pattern.Observer.Interfaces
{
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}
