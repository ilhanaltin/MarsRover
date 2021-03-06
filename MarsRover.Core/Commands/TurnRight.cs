using MarsRover.Core.Interfaces;
using MarsRover.Core.Receiver;

namespace MarsRover.Core.Commands
{
    public class TurnRight : ICommand
    {
        /// <summary>
        /// Rover
        /// </summary>
        private Rover _rover;

        /// <summary>
        /// constructor of TurnRight class that uses rover
        /// </summary>
        /// <param name="rover"></param>
        public TurnRight(Rover rover)
        {
            this._rover = rover;
        }

        /// <summary>
        /// executes the command
        /// </summary>
        public void Execute()
        {
            _rover.TurnRight();
        }
    }
}
