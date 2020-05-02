using Design.Patterns.AbstractFactory.Interfaces;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class ModernChair : IChair
    {
        public ModernChair()
        {
        }

        public ModernChair(bool hasLegs)
        {
            HasLegs = hasLegs;
        }

        public bool HasLegs { get; set; }
        public string GetType()
        {
            return $"Esta é uma cadeira Moderna {(HasLegs ? "modelo simples" : "com um modelo inovador")}";
        }
    }
}
