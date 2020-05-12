using Design.Patterns.Composite.Interfaces;
using System;
using System.Collections.Generic;

namespace Design.Patterns.Composite.Model
{
    public class QualityAnalyst : IEmployee
    {
        public QualityAnalyst(string name, decimal salary, IEnumerable<string> skills)
        {
            Name = name;
            Salary = salary;
            Skills = skills;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public IEnumerable<string> Skills { get; set; }

        public decimal GetSalary()
        {
            return Salary;
        }

        public void Show()
        {
            Console.WriteLine($"Analista de Qualidade: Nome: {Name}, Saláio: {Salary}, Habilidades: {string.Join(", ", Skills)}");
        }
    }
}
