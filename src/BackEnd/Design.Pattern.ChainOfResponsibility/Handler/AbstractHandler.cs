using Design.Pattern.ChainOfResponsibility.Interfaces;

namespace Design.Pattern.ChainOfResponsibility.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        protected IHandler _successor;

        public abstract void Execute(int request);

        public IHandler Next(IHandler successor)
        {
             _successor = successor;
            return this;
        }
    }
}
