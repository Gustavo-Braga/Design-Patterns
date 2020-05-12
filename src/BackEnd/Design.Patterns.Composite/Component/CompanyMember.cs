using Design.Patterns.Composite.Interfaces;
using System.Collections.Generic;

namespace Design.Patterns.Composite.Component
{
    public abstract class CompanyMember : IEmployee
    {
        public abstract string Description { get; set; }

        public abstract decimal GetSalary();
        public abstract void Show();
        public abstract void AddMember(IEmployee employee);
        public abstract void AddRangeMember(IEnumerable<IEmployee> employees);


    }
}
