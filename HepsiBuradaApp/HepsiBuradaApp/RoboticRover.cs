using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaApp
{
    public class RoboticRover
    {
        public Coordinate CurrentCoordinate { get; set; }
        public CompassPoints Direction { get; set; }

        private Plateau plateau;

        public RoboticRover(int x, int y, CompassPoints direction, Plateau plateau) {
            CurrentCoordinate = new Coordinate(x, y);
            Direction = direction;
            this.plateau = plateau;
        }

        public void TurnLeft()
        {
            if (Direction == CompassPoints.N)
            {
                Direction = CompassPoints.W;
            }
            else
            {
                Direction -= 1;
            }
        }

        public void TurnRight()
        {
            if (Direction == CompassPoints.W)
            {
                Direction = CompassPoints.N;
            } else
            {
                Direction += 1;
            }
        }

        public void Move()
        {
            if(Direction == CompassPoints.N)
            {
                if(plateau.IsInsidePlateau(CurrentCoordinate.X, CurrentCoordinate.Y + 1))
                {
                    CurrentCoordinate.Y += 1;
                } else
                {
                    Console.WriteLine($"Cannot move to ({CurrentCoordinate.X}, {CurrentCoordinate.Y + 1}) because it is outside plateau.");
                    Console.WriteLine($"Staying current coordinate ({CurrentCoordinate.X}, {CurrentCoordinate.Y}).");
                }
            } else if(Direction == CompassPoints.E)
            {
                if (plateau.IsInsidePlateau(CurrentCoordinate.X + 1, CurrentCoordinate.Y))
                {
                    CurrentCoordinate.X += 1;
                }
                else
                {
                    Console.WriteLine($"Cannot move to ({CurrentCoordinate.X + 1}, {CurrentCoordinate.Y}) because it is outside plateau.");
                    Console.WriteLine($"Staying current coordinate ({CurrentCoordinate.X}, {CurrentCoordinate.Y}).");
                }
            } else if(Direction == CompassPoints.S)
            {
                if (plateau.IsInsidePlateau(CurrentCoordinate.X, CurrentCoordinate.Y - 1))
                {
                    CurrentCoordinate.Y -= 1;
                }
                else
                {
                    Console.WriteLine($"Cannot move to ({CurrentCoordinate.X}, {CurrentCoordinate.Y - 1}) because it is outside plateau.");
                    Console.WriteLine($"Staying current coordinate ({CurrentCoordinate.X}, {CurrentCoordinate.Y}).");
                }
            } else
            {
                if (plateau.IsInsidePlateau(CurrentCoordinate.X - 1, CurrentCoordinate.Y))
                {
                    CurrentCoordinate.X -= 1;
                }
                else
                {
                    Console.WriteLine($"Cannot move to ({CurrentCoordinate.X - 1}, {CurrentCoordinate.Y}) because it is outside plateau.");
                    Console.WriteLine($"Staying current coordinate ({CurrentCoordinate.X}, {CurrentCoordinate.Y}).");
                }
            }
        }

        public void ApplyCommands(char[] commands)
        {
            foreach(var command in commands)
            {
                if(command == 'L')
                {
                    TurnLeft();
                } else if(command == 'R')
                {
                    TurnRight();
                } else if(command == 'M')
                {
                    Move();
                } else
                {
                    Console.WriteLine("Unexpected command");
                }
            }
        }
    }
}
