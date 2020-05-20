using Design.Pattern.Strategy.Interfaces;

namespace Design.Pattern.Strategy.Strategy
{
    public class DivisionStrategy : IStrategy
    {
        public DivisionStrategy(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        private int FirstNumber { get; set; }
        private int SecondNumber { get; set; }

        public string Execute()
        {
            return $"Resultado da divisão é: {FirstNumber} / {SecondNumber} = {(SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{FirstNumber / SecondNumber}")}";
        }
    }
}
