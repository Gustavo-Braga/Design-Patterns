using Design.Patterns.Memento.Interfaces;
using Design.Patterns.Memento.Memento;

namespace Design.Patterns.Memento.Model
{
    public class Person: IOriginator
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public IMemento Save()
        {
            return new PersonMemento((Person)MemberwiseClone());
        }
    }
}
