using Design.Pattern.Command.Interfaces;
using Design.Pattern.Command.Receiver;

namespace Design.Pattern.Command.Command
{
    public class SubtractionCommand : ICommand
    {
        private readonly SimpleCalculator _simpleCalculator;

        public SubtractionCommand(SimpleCalculator simpleCalculator)
        {
            _simpleCalculator = simpleCalculator;
        }

        public void Execute()
        {
            _simpleCalculator.Subtraction();
        }
    }
}
