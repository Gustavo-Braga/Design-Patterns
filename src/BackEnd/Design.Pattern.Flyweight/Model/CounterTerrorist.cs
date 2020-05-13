using Design.Pattern.Flyweight.Interfaces;
using System;

namespace Design.Pattern.Flyweight.Model
{
    public class CounterTerrorist : IPlayer
    {
        public string TaskPlayer { get; set; }
        private string Weapon { get; set; }

        public void AssignWeapon(string weapon)
        {
            Weapon = weapon;
        }

        public void Mission(string task)
        {
            TaskPlayer = $"Policial deve realizar o objetivo de {task}";
        }
        public bool IsTerrorist()
        {
            return false;
        }

        public void Show()
        {
            Console.WriteLine(TaskPlayer);
            Console.WriteLine($"Possui arma: {Weapon}");
        }
    }
}
