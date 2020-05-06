using Design.Patterns.Prototype.Interfaces;
using System;
using System.Collections.Generic;

namespace Design.Patterns.Prototype.Model
{
    public class Developer : IEmployee, ICloneable
    {
        public Developer(string name, double salary, IEnumerable<string> languages)
        {
            Name = name;
            Salary = salary;
            Languages = languages;
        }

        public string Name { get; set; }
        private double Salary { get; set; }
        public IEnumerable<string> Languages { get; set; }

        public IEmployee CloneEmployee()
        {
            return (Developer)MemberwiseClone();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name}, {Salary}, {string.Join(", ", Languages)}";
        }
    }
}
