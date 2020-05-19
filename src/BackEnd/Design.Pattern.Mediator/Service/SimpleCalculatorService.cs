using Design.Pattern.Mediator.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Pattern.Mediator.Service
{
    public class SimpleCalculatorService
    {
        public void Sum(SumComponent component)
        {
            Console.WriteLine($"A soma dos valores é {component.FirstNumber}+{component.SecondNumber} = {component.FirstNumber + component.SecondNumber}");
        }

        public void Subtraction(SubtractionComponent component)
        {
            Console.WriteLine($"A subtração dos valores é {component.FirstNumber}-{component.SecondNumber} = {component.FirstNumber - component.SecondNumber}");
        }

        public void Multiplication(MultiplicationComponent component)
        {
            Console.WriteLine($"A multiplicação dos valores é {component.FirstNumber}*{component.SecondNumber} = {component.FirstNumber * component.SecondNumber}");
        }

        public void Division(DivisionComponent component)
        {
            Console.WriteLine($"A divisão dos valores é {component.FirstNumber}/{component.SecondNumber} = {(component.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{component.FirstNumber / component.SecondNumber}")}");
        }
    }
}
