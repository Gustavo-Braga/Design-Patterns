using System;
using Design.Patterns.Memento.Interfaces;
using Design.Patterns.Memento.Model;

namespace Design.Patterns.Memento.Memento
{
    public class PersonMemento : IMemento
    {
        private Person _person;
        public DateTime Date { get; private set; }

        public PersonMemento(Person person)
        {
            _person = person;
            Date = DateTime.Now;
        }

        public IOriginator GetState()
        {
            return _person;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public void Show()
        {
            Console.WriteLine($"Pessoa: {_person.Name}, de {_person.Age} anos, {_person.Description}");
        }
    }
}
