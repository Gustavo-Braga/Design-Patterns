using Design.Patterns.Memento.Interfaces;
using System;
using System.Collections.Generic;

namespace Design.Patterns.Memento.Memento
{
    public class Caretaker
    {
        private Stack<IMemento> _stack = new Stack<IMemento>();
        private IOriginator _originator;
        public Caretaker(IOriginator originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            _stack.Push(_originator.Save());
        }

        public void Undo()
        {
            _stack.Pop();
        }

        public void ShowHistory()
        {
            foreach (var item in _stack)
            {
                Console.WriteLine($"{item.GetDate().ToString("dd/MM/yyyy HH:mm:ss")}");
                item.Show();
            }
        }
    }
}
