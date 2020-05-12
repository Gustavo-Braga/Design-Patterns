using Design.Patterns.Composite.Interfaces;
using System;

namespace Design.Patterns.Composite.Model
{
    public class Director : IEmployee
    {
        public Director(string name, decimal salary, string description)
        {
            Name = name;
            Salary = salary;
            Description = description;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Description { get; set; }

        public decimal GetSalary()
        {
            return Salary;
        }
        public void Show()
        {
            Console.WriteLine($"Diretor: Nome: {Name}, Saláio: {Salary}, Descrição: {Description}");
        }
    }
}
