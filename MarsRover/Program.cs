using MarsRover.Core.Helpers;
using MarsRover.Core.Invoker;
using MarsRover.Core.Receiver;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;

            List<Rover> rovers = new List<Rover>();

            Console.WriteLine("Enter Mars Plateu Width and Height Example: {5 5}:");

            var maxPoints = Console.ReadLine().Split(' ');

            var limitsOfPlateu = new List<int>();
            foreach (var m in maxPoints)
            {
                limitsOfPlateu.Add(Convert.ToInt32(m));
            }

            while (true)
            {
                Console.WriteLine("Enter position and direction of the rover: ");
                Console.WriteLine("Example: {1 2 N} {X Position; Y Position} { N = North; W = West; S = South; E = East }");

                input = Console.ReadLine().Split(' ');

                try
                {
                    var direction = RoverHelper.GetDirection(input[2].ToUpper());

                    Rover rover = new Rover(new Point(Convert.ToInt32(input[0]), Convert.ToInt32(input[1])), direction);

                    Console.WriteLine("Enter the directions for the rover to follow without spaces.");
                    Console.WriteLine("Example: {LMLMLMLMM} { L = Turn Left; R = Turn Right; M = Move 1 unit forward }");

                    string stringOfDirections = Console.ReadLine().Replace(" ", "");

                    foreach (char character in stringOfDirections.ToUpper())
                    {
                        var command = RoverHelper.GetCommand(character, rover, limitsOfPlateu);
                        Nasa nasa = new Nasa();
                        nasa.Execute(command);
                    }

                    rovers.Add(rover);
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine("Final location(s) of rover(s):");

            foreach (var r in rovers)
            {
                Console.WriteLine(r.Location);
            }

            Console.ReadLine();

            Environment.Exit(0);
        }
    }
}
