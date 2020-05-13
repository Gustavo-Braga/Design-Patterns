using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Pattern.Flyweight.Interfaces
{
    public interface IPlayer
    {
        void AssignWeapon(string weapon);
        void Mission(string task);
        bool IsTerrorist();
        void Show();
    }
}
