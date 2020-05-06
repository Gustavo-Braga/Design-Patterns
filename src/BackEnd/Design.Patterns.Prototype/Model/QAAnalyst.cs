using Design.Patterns.Prototype.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Design.Patterns.Prototype.Model
{
    public class QAAnalyst : IEmployee, ICloneable
    {
        public string Name { get; set; }
        private double Salary { get; set; }
        public IEnumerable<string> Frameworks{ get; set; }

        public IEmployee CloneEmployee()
        {
            return (QAAnalyst)MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this;
        }

        public override string ToString()
        {
            return $"{Name}, {Salary}, {string.Join(", ", Frameworks)}";
        }
    }
}
