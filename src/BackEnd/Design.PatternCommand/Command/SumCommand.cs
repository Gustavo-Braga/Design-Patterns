using Design.Pattern.Command.Interfaces;
using Design.Pattern.Command.Receiver;

namespace Design.Pattern.Command.Command
{
    public class SumCommand : ICommand
    {
        private readonly SimpleCalculator _simpleCalculator;

        public SumCommand(SimpleCalculator simpleCalculator)
        {
            _simpleCalculator = simpleCalculator;
        }

        public void Execute()
        {
            _simpleCalculator.Sum();
        }
    }
}
