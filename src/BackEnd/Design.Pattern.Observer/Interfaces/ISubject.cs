namespace Design.Pattern.Observer.Interfaces
{
    public interface ISubject<T>
    {
        void Attach(IObserver<T> observer);

        void Detach(IObserver<T> observer);

        void Notify(T entity);
    }
}
