using Design.Patterns.AbstractFactory.Interfaces;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class VictorianSofa : ISofa
    {
        public VictorianSofa()
        {
        }

        public VictorianSofa(string size)
        {
            Size = size;
        }

        public string Size { get; set; }
        public bool IsRetratil
        {
            get { return false; }
        }

        public string GetType()
        {
            return $"Este é um Sofá Vitoriano{(IsRetratil ? " retrátil" : "")}{(string.IsNullOrEmpty(Size) ? "" : $", com o tamanho {Size} m")}";
        }
    }
}
