using Design.Pattern.Observer.Interfaces;
using System.Collections.Generic;

namespace Design.Pattern.Observer.Subject
{
    public abstract class SubjectBase<T> : ISubject<T>
    {
        private IList<IObserver<T>> _observers = new List<IObserver<T>>();
        public void Attach(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(T entity)
        {
            foreach (var item in _observers)
                item.Update(entity);
        }
    }
}
