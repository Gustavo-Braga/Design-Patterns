using Design.Patterns.AbstractFactory.Interfaces;

namespace Design.Patterns.AbstractFactory.AbstractFactory
{
    public class VictorianChair : IChair
    {
        public VictorianChair()
        {
        }

        public VictorianChair(string texture, bool isMetallic)
        {
            Texture = texture;
            IsMetallic = isMetallic;
        }

        public string Texture { get; set; }
        public bool IsMetallic { get; set; }

        public string GetType()
        {
            return $"Esta é uma cadeira Vitoriana de textura {(string.IsNullOrEmpty(Texture)? "tecido": Texture)} e com acabamento {(IsMetallic? "metálico": "de madeira")}";
        }
    }
}
