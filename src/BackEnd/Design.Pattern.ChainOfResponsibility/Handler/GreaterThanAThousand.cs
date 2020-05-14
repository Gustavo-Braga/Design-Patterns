using System;

namespace Design.Pattern.ChainOfResponsibility.Handler
{
    public class GreaterThanAThousand:AbstractHandler
    {
        public override void Execute(int request)
        {
            Console.WriteLine($"Número {request} é maior que 1000: {(request > 1000 ? "Sim" : "Não")}");
            if (_successor != null)
                _successor.Execute(request);
        }
    }
}
