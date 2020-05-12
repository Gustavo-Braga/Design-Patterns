using Design.Patterns.Composite.Component;
using Design.Patterns.Composite.Composite;
using Design.Patterns.Composite.Model;
using System;
using System.Collections.Generic;

namespace Design.Patterns.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var randomSalary = new Random();
            var dev1 = new Developer("Lucas", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3", "skill4" });
            var dev2 = new Developer("Bruno", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3" });
            var dev3 = new Developer("Maria", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2" });

            var qa1 = new Developer("Julia", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3", "skill4" });
            var qa2 = new Developer("Pedro", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3" });
            var qa3 = new Developer("Lucia", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2" });
            var qa4 = new Developer("Roberto", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill5" });

            var sectorDev = new CompanySector("Desenvolvimento");
            sectorDev.AddMember(dev1);
            sectorDev.AddMember(dev2);
            sectorDev.AddMember(dev3);

            var sectorQA = new CompanySector("Qualidade");
            sectorQA.AddMember(qa1);
            sectorQA.AddMember(qa2);
            sectorQA.AddMember(qa3);
            sectorQA.AddMember(qa4);

            var tiDepartment = new CompanyDepartment("Tecnologia da Informação");
            var developerManager = new Manager("Adriana", GetRamdomSalary(randomSalary), "Gerente de Desenvolvimento");
            tiDepartment.AddMember(developerManager);
            tiDepartment.AddMember(sectorDev);

            var qualityAnalystManager = new Manager("Pedro", GetRamdomSalary(randomSalary), "Gerente de Qualidade");
            tiDepartment.AddMember(qualityAnalystManager);
            tiDepartment.AddMember(sectorQA);

            var rhManager = new Manager("Luisa", GetRamdomSalary(randomSalary), "Gerente de RH");
            var rhDepartment = new CompanyDepartment("Recursos Humanos");
            rhDepartment.AddMember(rhManager);

            var director = new Director("Nathália", GetRamdomSalary(randomSalary), "Dona da Empresa");
            var headQuarters = new CompanyHeadquarters("Matriz");
            headQuarters.AddMember(director);
            headQuarters.AddRangeMember(new List<CompanyMember> { rhDepartment, tiDepartment });

            Console.WriteLine($"Salario total: {headQuarters.GetSalary()}");
            headQuarters.Show();
            Console.ReadKey();
        }

        public static int GetRamdomSalary(Random randomSalary)
        {
            return randomSalary.Next(0, 10000);
        }
    }
}
