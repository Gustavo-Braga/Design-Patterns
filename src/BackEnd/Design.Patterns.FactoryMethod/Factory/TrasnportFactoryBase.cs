using Design.Patterns.FactoryMethod.Enum;
using Design.Patterns.FactoryMethod.Interfaces;

namespace Design.Patterns.FactoryMethod.Factory
{
    public abstract class TrasnportFactoryBase
    {
        abstract public ITransport GetTransport(Transport transportType);
    }
}
