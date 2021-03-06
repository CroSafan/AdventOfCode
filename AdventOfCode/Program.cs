﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class Mapper
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction direction = Direction.North;

        public Mapper()
        {
            X = 0;
            Y = 0;
        }

        public int LocationVisitedTwice(string input)
        {
            string locationVisitedTwice = String.Empty;
            List<string> locationsVisited = new List<string>();
            bool locationFound = false;

            string[] moves = Array.ConvertAll(input.Split(','), x => x.Trim());
            foreach (var move in moves)
            {
                string turn = move[0].ToString();
                int steps = Convert.ToInt32(move.Substring(1, move.Length - 1));

                switch (turn)
                {
                    case "L":
                        if (direction == Direction.North)
                            direction = Direction.West;
                        else direction--;
                        break;

                    case "R":
                        if (direction == Direction.West)
                            direction = Direction.North;
                        else direction++;
                        break;

                    default:
                        break;
                }

                switch (direction)
                {
                    case Direction.North:
                        for (int i = 0; i < steps; i++)
                        {
                            this.Y++;
                            string currentLocation = this.X.ToString() + "," + this.Y.ToString();
                            if (locationsVisited.Contains(currentLocation) && locationFound == false)
                            {
                                locationVisitedTwice = currentLocation;
                                locationFound = true;
                            }
                            else
                            {
                                locationsVisited.Add(currentLocation);
                            }
                        }
                        //this.Y += steps;
                        break;

                    case Direction.South:
                        for (int i = 0; i < steps; i++)
                        {
                            this.Y--;
                            string currentLocation = this.X.ToString() + "," + this.Y.ToString();
                            if (locationsVisited.Contains(currentLocation) && locationFound == false)
                            {
                                locationVisitedTwice = currentLocation;
                                locationFound = true;

                            }
                            else
                            {
                                locationsVisited.Add(currentLocation);

                            }
                        }
                        //this.Y -= steps;
                        break;

                    case Direction.East:
                        for (int i = 0; i < steps; i++)
                        {
                            this.X++;
                            string currentLocation = this.X.ToString() + "," + this.Y.ToString();
                            if (locationsVisited.Contains(currentLocation) && locationFound == false)
                            {
                                locationVisitedTwice = currentLocation;
                                locationFound = true;

                            }
                            else
                            {
                                locationsVisited.Add(currentLocation);
                            }
                        }
                        // this.X += steps;
                        break;

                    case Direction.West:
                        for (int i = 0; i < steps; i++)
                        {
                            this.X--;
                            string currentLocation = this.X.ToString() + "," + this.Y.ToString();
                            if (locationsVisited.Contains(currentLocation) && locationFound == false)
                            {
                                locationVisitedTwice = currentLocation;
                                locationFound = true;
                            }
                            else
                            {
                                locationsVisited.Add(currentLocation);
                            }
                        }
                        // this.X -= steps;
                        break;
                }


            }
            string[] foundLocation = locationVisitedTwice.Split(',');
            int X = Convert.ToInt32(foundLocation[0].ToString());
            int Y = Convert.ToInt32(foundLocation[1].ToString());
            return Math.Abs(X) + Math.Abs(Y);
        }

        public int GetBlocks(string input)
        {
            string[] moves = Array.ConvertAll(input.Split(','), x => x.Trim());
            foreach (var move in moves)
            {
                string turn = move[0].ToString();
                int steps = Convert.ToInt32(move.Substring(1, move.Length - 1));

                switch (turn)
                {
                    case "L":
                        if (direction == Direction.North)
                            direction = Direction.West;
                        else direction--;
                        break;

                    case "R":
                        if (direction == Direction.West)
                            direction = Direction.North;
                        else direction++;
                        break;

                    default:
                        break;
                }

                switch (direction)
                {
                    case Direction.North:
                        this.Y += steps;
                        break;

                    case Direction.South:
                        this.Y -= steps;
                        break;

                    case Direction.East:
                        this.X += steps;
                        break;

                    case Direction.West:
                        this.X -= steps;
                        break;
                }
            }
            return Math.Abs(this.X) + Math.Abs(this.Y);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Mapper x = new Mapper();
            StreamReader sr = new StreamReader(@"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCode\input.txt");
            string input = sr.ReadLine();

            // Console.WriteLine(x.GetBlocks(input));
            Console.WriteLine(x.LocationVisitedTwice(input));
            Console.Read();
        }
    }
}