using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay8
{
    class Program
    {
        public static char[,] screen = new char[6, 50];
        public static void CreateRect(int row, int column)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row ; j++)
                {
                    screen[i, j] = '#';
                }
            }
        }

        public static void RotateColumnDown(int x,int n)
        {

        }
        public static void RotateRowRight(int y,int n)
        {

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
        static void Main(string[] args)
        {
            CreateScreen();
            DrawScreen();
            Console.WriteLine();
            CreateRect(3,2);
            DrawScreen();








            Console.Read();
        }
    }
}
