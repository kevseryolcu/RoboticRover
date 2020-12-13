using System;
using System.IO;
using System.Reflection;

namespace HepsiBuradaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Inputs.txt");

                if(lines.Length < 3)
                {
                    Console.WriteLine("Input file content is not correct.");
                    return;
                }

                var upperRightCoordinates = lines[0].Split(' ');
                int x, y;
                Plateau plateau;

                if(upperRightCoordinates.Length != 2)
                {
                    Console.WriteLine("In input file, plateau upper right coordinate is not correct.");
                    return;
                }

                if(!(int.TryParse(upperRightCoordinates[0], out x) && int.TryParse(upperRightCoordinates[1], out y)))
                {
                    Console.WriteLine("In input file, plateau upper right coordinate is not correct.");
                    return;
                }

                plateau = new Plateau(x, y);
                for (var i = 1; i < lines.Length; i += 2)
                {
                    var position = lines[i].Split(' ');
                    RoboticRover rover;
                    if (position.Length == 3 && i+1 < lines.Length)
                    {
                        if(int.TryParse(position[0], out x) && int.TryParse(position[1], out y) && Enum.IsDefined(typeof(CompassPoints), position[2]))
                        {
                            rover = new RoboticRover(x, y, (CompassPoints)Enum.Parse(typeof(CompassPoints), position[2]), plateau);

                            Console.WriteLine($"Rover started at ({x} {y} {rover.Direction}) with plateau"
                                        + $"({plateau.LowerLeftCorner.X}, {plateau.LowerLeftCorner.Y})"
                                        + $"({plateau.LowerRightCorner.X}, {plateau.LowerRightCorner.Y})"
                                        + $"({plateau.UpperRightCorner.X}, {plateau.UpperRightCorner.Y})");
                            Console.WriteLine($"Applying commands: {lines[i + 1]}");
                            rover.ApplyCommands(lines[i + 1].ToCharArray());

                            Console.WriteLine($"Final position: {rover.CurrentCoordinate.X} {rover.CurrentCoordinate.Y} {rover.Direction}\n");
                        }
                        else
                        {
                            Console.WriteLine($"Wrong position information: ({lines[i]})");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Wrong position information: ({lines[i]})");
                    }
                }

            } catch (FileNotFoundException fnex)
            {
                Console.WriteLine("Input file not found!");
            } catch (Exception ex) {
                Console.WriteLine("An exception occured while reading Input.txt, " + ex);
            }

        }
    }
}
