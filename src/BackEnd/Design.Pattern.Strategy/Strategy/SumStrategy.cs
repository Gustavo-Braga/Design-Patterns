using Design.Pattern.Strategy.Interfaces;

namespace Design.Pattern.Strategy.Strategy
{
    public class SumStrategy : IStrategy
    {
        public SumStrategy(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        private int FirstNumber { get; set; }
        private int SecondNumber { get; set; }

        public string Execute()
        {
            return $"Resultado da soma é: {FirstNumber} + {SecondNumber} = {FirstNumber + SecondNumber}";
        }
    }
}
