using Design.Pattern.State.Client;
using Design.Pattern.State.Interfaces;
using System;

namespace Design.Pattern.State.State
{
    public class DivisionState : IStateSimpleCalculator
    {
        public void Execute(SimpleCalculator context)
        {
            Console.WriteLine($"Resultado da divisão é: {context.FirstNumber} / {context.SecondNumber} = {(context.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{context.FirstNumber / context.SecondNumber}")}");
        }
    }
}
