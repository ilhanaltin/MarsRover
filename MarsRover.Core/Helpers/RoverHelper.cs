using MarsRover.Core.Commands;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Receiver;
using MarsRover.Data.Constants;
using System;
using System.Collections.Generic;

namespace MarsRover.Core.Helpers
{
    public class RoverHelper
    {
        /// <summary>
        /// returns Direction enum from string of direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Direction</returns>
        public static Directions GetDirection(string direction)
        {
            switch (direction)
            {
                case "N":
                    return Directions.N;
                case "E":
                    return Directions.E;
                case "S":
                    return Directions.S;
                case "W":
                    return Directions.W;
            }

            return Directions.N;
        }

        /// <summary>
        /// returns command object by using parameters
        /// command type, rover and limits of plateau
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="rover"></param>
        /// <param name="limits"></param>
        /// <returns>ICommand</returns>
        public static ICommand GetCommand(char letter, Rover rover, List<int> limits = null)
        {
            switch (char.ToUpper(letter))
            {
                case 'L':
                    return new TurnLeft(rover);

                case 'R':
                    return new TurnRight(rover);

                case 'M':
                    return new Move(rover, limits);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
