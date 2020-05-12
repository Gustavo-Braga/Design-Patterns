using Design.Patterns.Composite.Component;
using Design.Patterns.Composite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Patterns.Composite.Composite
{
    public class CompanySector: CompanyMember
    {
        private List<IEmployee> _companyMembers { get; set; }

        public CompanySector(string description)
        {
            Description = description;
            _companyMembers = new List<IEmployee>();
        }

        public override string Description { get; set; }

        public override decimal GetSalary()
        {
            return _companyMembers.Sum(x => x.GetSalary());
        }

        public override void AddMember(IEmployee employee)
        {
            _companyMembers.Add(employee);
        }
        public override void AddRangeMember(IEnumerable<IEmployee> employees)
        {
            _companyMembers.AddRange(employees);
        }

        public override void Show()
        {
            Console.WriteLine($"Setor: {Description}");
            foreach (var item in _companyMembers)
            {
                item.Show();
            }
        }
    }
}
