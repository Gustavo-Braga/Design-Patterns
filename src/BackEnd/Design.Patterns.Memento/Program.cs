using Design.Patterns.Memento.Memento;
using Design.Patterns.Memento.Model;
using System;

namespace Design.Patterns.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var person = new Person();
            var caretaker = new Caretaker(person);
            person.Name = "Gustavo";
            caretaker.Backup();
            person.Age = 23;
            caretaker.Backup();
            person.Description = "lorem ipsum";
            caretaker.Backup();
            person.Description = "lorem ipsum - 2";
            caretaker.Backup();
            caretaker.ShowHistory();

            caretaker.Undo();
            caretaker.Undo();
            caretaker.Undo();

            caretaker.ShowHistory();



            Console.ReadKey();
        }
    }
}
