using Design.Pattern.Strategy.Interfaces;

namespace Design.Pattern.Strategy.Strategy
{
    public class SubtractionStrategy : IStrategy
    {
        public SubtractionStrategy(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        private int FirstNumber { get; set; }
        private int SecondNumber { get; set; }

        public string Execute()
        {
            return $"Resultado da subtração é: {FirstNumber} - {SecondNumber} = {FirstNumber - SecondNumber}";
        }
    }
}
