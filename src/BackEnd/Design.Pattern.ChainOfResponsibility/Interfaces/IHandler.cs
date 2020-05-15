namespace Design.Pattern.ChainOfResponsibility.Interfaces
{
    public interface IHandler
    {
        void Execute(int request);
        IHandler Next(IHandler successor);
    }
}
