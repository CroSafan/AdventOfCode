using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay3
{

    public class Triangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }


        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public bool IsRealTriangle()
        {
            return (A + B > C) && (B + C > A) && (C + A > B);
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> trueTriangle = new List<Triangle>();
            StreamReader sr = new StreamReader(@"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay3\input.txt");
            List<string> lines = new List<string>();
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }
            foreach (var line in lines)
            {
                var triangle = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                Triangle x = new Triangle(Convert.ToInt32(triangle[0]), Convert.ToInt32(triangle[1]), Convert.ToInt32(triangle[2]));

                if (x.IsRealTriangle())
                {
                    trueTriangle.Add(x);
                }
            }
            Console.WriteLine(trueTriangle.Count);
            Console.Read();
        }
    }
}
