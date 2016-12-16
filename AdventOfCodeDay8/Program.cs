using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay8
{
    internal class Program
    {
        public static char[,] screen = new char[6, 50];

        public static void CreateRect(int row, int column)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    screen[i, j] = '#';
                }
            }
        }

        public static void RotateColumnDown(int x, int n)
        {
            while (n != 0)
            {
                var temp = screen[screen.GetLength(0) - 1, x];

                for (int i = screen.GetLength(0) - 1; i > 0; i--)
                {
                    screen[i, x] = screen[i - 1, x];
                }
                screen[0, x] = temp;
                n--;
            }
        }

        public static void ParseInstuction(string input)
        {
            if (input.Contains("rect"))
            {
                CreateRect(Convert.ToInt32(input.Split(' ')[1].Split('x')[0]), Convert.ToInt32(input.Split(' ')[1].Split('x')[1]));
            }
            else if (input.Contains("row"))
            {
                int by = Convert.ToInt32(input.Split(' ')[4]);
                var number = Convert.ToInt32(input.Split(' ')[2].Split('=')[1]);
                RotateRowRight(number, by);
            }
            else if (input.Contains("column"))
            {
                int by = Convert.ToInt32(input.Split(' ')[4]);
                var number = Convert.ToInt32(input.Split(' ')[2].Split('=')[1]);
                RotateColumnDown(number, by);
            }
        }

        public static void RotateRowRight(int y, int n)
        {
            while (n != 0)
            {
                var temp = screen[y, screen.GetLength(1) - 1];

                for (int i = screen.GetLength(1) - 1; i > 0; i--)
                {
                    screen[y, i] = screen[y, i - 1];
                }
                screen[y, 0] = temp;
                n--;
            }
        }

        public static void DrawScreen()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Console.Write(screen[i, j]);
                }
                Console.WriteLine("\n");
            }
        }

        public static void CreateScreen()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    screen[i, j] = '.';
                }
            }
        }

        public static int CheckHowManyLit()
        {
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (screen[i, j] == '#')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private static void Main(string[] args)
        {
            CreateScreen();
            //DrawScreen();
            Console.WriteLine();

            string pathToInput = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay8\input.txt";
            List<string> input = new List<string>();
            StreamReader sr = new StreamReader(pathToInput);

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            foreach (var line in input)
            {
                ParseInstuction(line);
            }

            DrawScreen();
            Console.WriteLine(CheckHowManyLit());

            Console.Read();
        }
    }
}