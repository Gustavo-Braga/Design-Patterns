using Design.Patterns.FactoryMethod.Interfaces;

namespace Design.Patterns.FactoryMethod.Factory
{
    public class Ship : ITransport
    {
        public string Deliver(int miles)
        {
            return $"O valor para o transporte marítimo é {miles * 12}";
        }
    }
}
