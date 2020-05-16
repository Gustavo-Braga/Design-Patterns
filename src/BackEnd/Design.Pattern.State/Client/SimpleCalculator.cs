using Design.Pattern.State.Interfaces;

namespace Design.Pattern.State.Client
{
    public class SimpleCalculator
    {
        private IStateSimpleCalculator _stateSimpleCalculator;

        public SimpleCalculator(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public Operation Operation { get; set; }

        public void SetState(IStateSimpleCalculator state)
        {
            _stateSimpleCalculator = state;
        }

        public void ExecuteState()
        {
            _stateSimpleCalculator?.Execute(this);
        }
    }

    public enum Operation
    {
        Sum,
        Subtraction,
        Multiplication,
        Division
    }

}
