using Design.Patterns.AbstractFactory.Interfaces;
using System;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class VictorianFurniture: IFurnitureFactory
    {
        public IChair CreateChair(string texture, bool isMetallic)
        {
            return new VictorianChair(texture, isMetallic);
        }

        public ISofa CreateSofa(string size)
        {
            return new VictorianSofa(size);
        }

        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ISofa CreateSofa()
        {
            return new VictorianSofa();
        }
    }
}
