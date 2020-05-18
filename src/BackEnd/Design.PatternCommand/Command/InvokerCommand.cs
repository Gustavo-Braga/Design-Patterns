using Design.Pattern.Command.Interfaces;
using System.Collections.Generic;

namespace Design.Pattern.Command.Command
{
    public class InvokerCommand
    {
        public List<ICommand> _commands = new List<ICommand>();

        public InvokerCommand()
        {
        }

        public InvokerCommand SetCommand(ICommand command)
        {
            _commands.Add(command);
            return this;
        }

        public void Execute()
        {
            foreach (var item in _commands)
                item.Execute();
        }
    }
}
