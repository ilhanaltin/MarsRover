using MarsRover.Core.Interfaces;
using MarsRover.Core.Receiver;

namespace MarsRover.Core.Commands
{
    public class TurnLeft : ICommand
    {
        /// <summary>
        /// Rover
        /// </summary>
        private Rover _rover;

        /// <summary>
        /// constructor of TurnLeft class that uses rover
        /// </summary>
        /// <param name="rover"></param>
        public TurnLeft(Rover rover)
        {
            this._rover = rover;
        }

        /// <summary>
        /// executes the command
        /// </summary>
        public void Execute()
        {
            _rover.TurnLeft();
        }
    }
}
