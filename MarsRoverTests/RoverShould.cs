using MarsRover.Core.Helpers;
using MarsRover.Core.Invoker;
using MarsRover.Core.Receiver;
using MarsRover.Data.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace MarsRoverTests
{
    public class RoverShould
    {
        private readonly List<int> limitsOfPlateu = new List<int>();

        /// <summary>
        /// constructor of RoverShould test class that initialize olateu limits
        /// </summary>
        public RoverShould()
        {
            limitsOfPlateu.Add(5);
            limitsOfPlateu.Add(5);
        }

        /// <summary>
        /// test for TurnLeft command
        /// </summary>
        [Fact]
        public void TurnLeft()
        {
            //arrange

            Rover rover = new Rover(new Point(1, 2), Directions.N);

            var command = RoverHelper.GetCommand('L', rover);

            //act
            Nasa nasa = new Nasa();
            nasa.Execute(command);

            //assert
            Assert.Equal(Directions.W, rover.Direction);
        }

        /// <summary>
        /// test for TurnRight command
        /// </summary>
        [Fact]
        public void TurnRight()
        {
            //arrange

            Rover rover = new Rover(new Point(1, 2), Directions.N);

            var command = RoverHelper.GetCommand('R', rover);

            //act
            Nasa nasa = new Nasa();
            nasa.Execute(command);

            //assert
            Assert.Equal(Directions.E, rover.Direction);
        }

        /// <summary>
        /// test for Move Forward command
        /// </summary>
        [Fact]
        public void Move()
        {
            //arrange

            Rover rover = new Rover(new Point(1, 2), Directions.N);

            var command = RoverHelper.GetCommand('M', rover, limitsOfPlateu);

            //act
            Nasa nasa = new Nasa();
            nasa.Execute(command);

            //assert
            Assert.Equal(3, rover.Y);
        }

        /// <summary>
        /// test for Give Destination 1 3 N
        /// </summary>
        [Fact]
        public void CanArriveToGivenDestination_1()
        {
            Rover rover = new Rover(new Point(1, 2), Directions.N);

            string directions = "LMLMLMLMM";

            foreach (char character in directions)
            {
                var command = RoverHelper.GetCommand(character, rover, limitsOfPlateu);
                Nasa nasa = new Nasa();
                nasa.Execute(command);
            }

            Assert.Equal("1 3 N", rover.Location);
        }

        /// <summary>
        /// test for Give Destination 5 1 E
        /// </summary>
        [Fact]
        public void CanArriveToGivenDestination_2()
        {
            Rover rover = new Rover(new Point(3, 3), Directions.E);

            string directions = "MMRMMRMRRM";

            foreach (char character in directions)
            {
                var command = RoverHelper.GetCommand(character, rover, limitsOfPlateu);
                Nasa nasa = new Nasa();
                nasa.Execute(command);
            }

            Assert.Equal("5 1 E", rover.Location);
        }
    }
}
