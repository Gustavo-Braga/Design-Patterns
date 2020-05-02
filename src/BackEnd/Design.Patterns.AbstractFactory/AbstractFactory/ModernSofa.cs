using Design.Patterns.AbstractFactory.Interfaces;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class ModernSofa:ISofa
    {
        public ModernSofa()
        {
        }

        public ModernSofa(string size, bool isRetratil)
        {
            Size = size;
            IsRetratil = isRetratil;
        }

        public string Size { get; set; }
        public bool IsRetratil { get; set; }

        public string GetType()
        {
            return $"Este é um Sofá Moderno{(IsRetratil ? " retrátil" : "")}{(string.IsNullOrEmpty(Size)?"" :$", com o tamanho {Size} m" )}";
        }
    }
}
