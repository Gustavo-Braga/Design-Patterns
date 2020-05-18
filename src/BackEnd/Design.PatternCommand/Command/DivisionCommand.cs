using Design.Pattern.Command.Interfaces;
using Design.Pattern.Command.Receiver;

namespace Design.Pattern.Command.Command
{
    public class DivisionCommand : ICommand
    {
        private readonly SimpleCalculator _simpleCalculator;

        public DivisionCommand(SimpleCalculator simpleCalculator)
        {
            _simpleCalculator = simpleCalculator;
        }

        public void Execute()
        {
            _simpleCalculator.Division();
        }
    }
}