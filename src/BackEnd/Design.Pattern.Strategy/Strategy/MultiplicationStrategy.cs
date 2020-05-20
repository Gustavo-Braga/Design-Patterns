using Design.Pattern.Strategy.Interfaces;

namespace Design.Pattern.Strategy.Strategy
{

    public class MultiplicationStrategy : IStrategy
    {
        public MultiplicationStrategy(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        private int FirstNumber { get; set; }
        private int SecondNumber { get; set; }

        public string Execute()
        {
            return $"Resultado da multplicação é: {FirstNumber} * {SecondNumber} = {FirstNumber * SecondNumber}";
        }
    }
}
