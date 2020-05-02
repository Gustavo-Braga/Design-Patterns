using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Patterns.AbstractFactory.Interfaces
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
}
