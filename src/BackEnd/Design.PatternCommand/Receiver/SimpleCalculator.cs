using System;

namespace Design.Pattern.Command.Receiver
{
    public class SimpleCalculator
    {
        public SimpleCalculator(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public void Sum()
        {
            Console.WriteLine($"A soma dos valores é {FirstNumber}+{SecondNumber} = {FirstNumber + SecondNumber}");
        }

        public void Subtraction()
        {
            Console.WriteLine($"A subtração dos valores é {FirstNumber}-{SecondNumber} = {FirstNumber - SecondNumber}");
        }

        public void Multiplication()
        {
            Console.WriteLine($"A multiplicação dos valores é {FirstNumber}*{SecondNumber} = {FirstNumber * SecondNumber}");
        }

        public void Division()
        {
            Console.WriteLine($"A divisão dos valores é {FirstNumber}/{SecondNumber} = {(SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{FirstNumber / SecondNumber}")}");
        }

    }
}
