using MarsRover.Core.Interfaces;
using MarsRover.Core.Receiver;
using System.Collections.Generic;

namespace MarsRover.Core.Commands
{
    public class Move : ICommand
    {
        /// <summary>
        /// limit of plateau
        /// </summary>
        private List<int> _limits = new List<int>();

        /// <summary>
        /// Rover
        /// </summary>
        private Rover _rover;

        /// <summary>
        /// constructor of Move class that uses rover and _limits
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="limits"></param>
        public Move(Rover rover, List<int> limits)
        {
            this._limits = limits;
            this._rover = rover;
        }

        /// <summary>
        /// executes the command
        /// </summary>
        public void Execute()
        {
            _rover.Move(this._limits);
        }
    }
}
