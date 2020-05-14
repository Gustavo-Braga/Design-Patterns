using System;

namespace Design.Pattern.ChainOfResponsibility.Handler
{
    public class EvenNumber: AbstractHandler
    {
        public override void Execute(int request)
        {
            Console.WriteLine($"Número {request} é par: {(request % 2 == 0?"Sim": "Não")}");
            if (_successor != null)
                _successor.Execute(request);
        }
    }
}
