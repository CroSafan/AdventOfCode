using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeDay7
{
    class Program
    {
        public static bool isAbba(string input)
        {
            if (input[0] == input[3] && input[1] == input[2] && input[0] != input[2] && input[1] != input[3]) return true;
            else return false;
        }
       
        public static bool isTLS(string input)
        {
            bool istls = false;
            var hypernet = input.Split('[', ']');
            foreach(string hyper in hypernet)
            {
                for (int i = 0; i < hyper.Length-4; i=i+4)
                {
                    string check = hyper[i] +""+ hyper[i + 1]+"" + hyper[i + 2]+""+hyper[i+3];
                    istls = isAbba(hyper);
                }
            }

            return istls;
        }

        static void Main(string[] args)
        {
            string pathToInput = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay7\input.txt";
            List<string> input = new List<string>();
            StreamReader sr = new StreamReader(pathToInput);

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }
            foreach (var line in input)
            {

            }
        }
    }
}
