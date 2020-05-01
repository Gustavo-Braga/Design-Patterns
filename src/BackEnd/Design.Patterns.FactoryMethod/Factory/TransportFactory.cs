using Design.Patterns.FactoryMethod.Enum;
using Design.Patterns.FactoryMethod.Interfaces;

namespace Design.Patterns.FactoryMethod.Factory
{
    public class TransportFactory : TrasnportFactoryBase
    {
        public override ITransport GetTransport(Transport transportType)
        {
            switch (transportType)
            {
                case Transport.Maritime:
                    return new Ship();
                case Transport.Road:
                    return new Truck();
                default: return new Truck();
            }
        }
    }
}
