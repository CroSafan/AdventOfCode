using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay6
{
    internal class Program
    {

        private static string ReturnMostCommonLetter(string word)
        {
            char[] wordChars = word.ToCharArray();
            List<char> distinctChars = wordChars.Distinct().Except(new[] { '-' }).ToList();
            Dictionary<char, int> occurrences = distinctChars.ToDictionary(c => c,
                                                                           c => wordChars.Count(x => x.Equals(c)));
            return new string(
                       occurrences.OrderByDescending(x => x.Value)
                                  .ThenBy(x => x.Key)
                                  .Select(x => x.Key)
                                  .Take(1)
                                  .ToArray());
        }

        private static void Main(string[] args)
        {

            string pathToInput = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay6\input.txt";
            string pathToTestInput = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay6\testinput.txt";
            string code = "";
            string mostCommon = "";
            int brojac = 0;

            List<string> input = new List<string>();
            StreamReader sr = new StreamReader(pathToInput);

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            while (brojac < input[0].Length)
            {
                foreach (var word in input)
                {
                    mostCommon += word[brojac];
                }
                brojac++;
                code += ReturnMostCommonLetter(mostCommon);
                mostCommon = "";
            }

            Console.WriteLine(code);
            Console.Read();


        }
    }
}