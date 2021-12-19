using MarsRover.Core.Interfaces;
using System.Collections.Generic;

namespace MarsRover.Core.Invoker
{
    public class Nasa
    {
        private List<ICommand> _commands = new List<ICommand>();

        /// <summary>
        /// stores and executes command rotation/movement from world
        /// </summary>
        public void Execute(ICommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }
}
