using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay2
{
    public static class Helper
    {
        public static int[,] keypad = new int[3, 3]
        {
             { 1, 2, 3},
             { 4, 5, 6},
             { 7, 8, 9},
        };

        private static int currentPosX = 1;
        private static int currentPosY = 1;

        public static string ReturnCode(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<string> lines = new List<string>();
            string code = "";

            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }
            foreach (var line in lines)
            {
                char[] chararray = line.ToCharArray();
                string currentDigit = "";

                foreach (var character in chararray)
                {
                    switch (character)
                    {
                        case 'U':
                            if (currentPosX > 0)
                            {
                                currentPosX--;

                            }
                            else if (currentPosY < 0) currentPosX = 0;

                            break;

                        case 'R':
                            if (currentPosY < 2)
                            {
                                currentPosY++;

                            }
                            else if (currentPosY > 2) currentPosY = 2;

                            break;

                        case 'L':
                            if (currentPosY > 0)
                            {
                                currentPosY--;

                            }
                            else if (currentPosY < 0) currentPosY = 0;

                            break;

                        case 'D':
                            if (currentPosX < 2)
                            {
                                currentPosX++;

                            }
                            else if (currentPosX > 2) currentPosX = 2;
                            break;
                        default:
                            break;
                    }
                    currentDigit = keypad[currentPosX, currentPosY].ToString();
                }
                code += currentDigit;
            }

            return code;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay2\input2.txt";
            Console.WriteLine(Helper.ReturnCode(path));
            Console.Read();
        }
    }
}