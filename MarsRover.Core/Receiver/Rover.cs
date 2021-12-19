using MarsRover.Data.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRover.Core.Receiver
{
    public class Rover
    {
        /// <summary>
        /// all directions created as an LinkedList to simulate the loop simply 
        /// </summary>
        static readonly LinkedList<Directions> directions =
                    new LinkedList<Directions>(new[] { Directions.N, Directions.W, Directions.S, Directions.E });

        /// <summary>
        /// X coordinate of rover
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate of rover
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// direction of rovew { Directions.N, Directions.W, Directions.S, Directions.E }
        /// </summary>
        public Directions Direction { get; set; }

        /// <summary>
        /// constructor of Rover class that uses position as a Point and direction as Directions enum
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Rover(Point position, Directions direction)
        {
            this.Direction = direction;
            this.X = position.X;
            this.Y = position.Y;
        }

        /// <summary>
        /// Moves forward the rover
        /// </summary>
        /// <param name="_limits"></param>
        public void Move(List<int> _limits)
        {
            switch (this.Direction)
            {
                case Directions.N:
                    if (Y >= _limits[1])
                        Console.WriteLine("Out of Plateu! Can't Move!");
                    else
                        Y += 1;
                    break;

                case Directions.E:
                    if (X >= _limits[0])
                        Console.WriteLine("Out of Plateu! Can't Move!");
                    else
                        X += 1;
                    break;

                case Directions.S:
                    if (Y != 0)
                        Y -= 1;
                    else
                        Console.WriteLine("Out of Plateu! Can't Move!");
                    break;

                case Directions.W:
                    if (X != 0)
                        X -= 1;
                    else
                        Console.WriteLine("Out of Plateu! Can't Move!");
                    break;
            }
        }

        /// <summary>
        /// executes the TurnLeft command
        /// </summary>
        public void TurnLeft()
        {
            LinkedListNode<Directions> currentIndex = directions.Find(this.Direction);

            if (currentIndex.Next == null)
                this.Direction = currentIndex.List.First.Value;
            else
                this.Direction = currentIndex.Next.Value;
        }

        /// <summary>
        /// executes the TurnRight command
        /// </summary>
        public void TurnRight()
        {
            LinkedListNode<Directions> currentIndex = directions.Find(this.Direction);

            if (currentIndex.Previous == null)
                this.Direction = currentIndex.List.Last.Value;
            else
                this.Direction = currentIndex.Previous.Value;
        }

        /// <summary>
        /// returns the current location of Rover
        /// </summary>
        public string Location
        {
            get
            {
                StringBuilder final = new StringBuilder();
                final.Append(this.X);
                final.Append(" ");
                final.Append(this.Y);
                final.Append(" ");

                switch (this.Direction)
                {
                    case Directions.N:
                        final.Append("N");
                        break;
                    case Directions.E:
                        final.Append("E");
                        break;
                    case Directions.S:
                        final.Append("S");
                        break;
                    case Directions.W:
                        final.Append("W");
                        break;
                }

                return final.ToString();
            }
        }
    }
}