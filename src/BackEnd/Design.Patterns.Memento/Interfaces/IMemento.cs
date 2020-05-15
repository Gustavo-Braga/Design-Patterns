using System;

namespace Design.Patterns.Memento.Interfaces
{
    public interface IMemento
    {
        IOriginator GetState();
        DateTime GetDate();
        void Show();
    }
}
