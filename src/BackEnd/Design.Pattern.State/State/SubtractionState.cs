using Design.Pattern.State.Client;
using Design.Pattern.State.Interfaces;
using System;

namespace Design.Pattern.State.State
{
    public class SubtractionState : IStateSimpleCalculator
    {
        public void Execute(SimpleCalculator context)
        {
            Console.WriteLine($"Resultado da subtração é: {context.FirstNumber} - {context.SecondNumber} = {context.FirstNumber - context.SecondNumber}");
        }
    }
}
