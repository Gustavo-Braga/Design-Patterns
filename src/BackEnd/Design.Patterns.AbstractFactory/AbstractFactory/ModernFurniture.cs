using Design.Patterns.AbstractFactory.Interfaces;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class ModernFurniture : IFurnitureFactory
    {
        public IChair CreateChair(bool hasLegs)
        {
            return new ModernChair(hasLegs);
        }

        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa(string size, bool isRetratil)
        {
            return new ModernSofa(size, isRetratil);
        }
        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }
}
