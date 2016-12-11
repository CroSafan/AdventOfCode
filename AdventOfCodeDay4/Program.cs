using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeDay4
{
    public static class Solver
    {
        public static string ReturnCode(string input)
        {
            Regex RoomNameMatch = new Regex(@"^[A-z-]+");
            string room = RoomNameMatch.Match(input).ToString();


            char[] roomChars = room.ToCharArray();
            List<char> distinctChars = roomChars.Distinct().Except(new[] { '-' }).ToList();
            Dictionary<char, int> occurrences = distinctChars.ToDictionary(c => c,
                                                                           c => roomChars.Count(x => x.Equals(c)));
            return new string(
                       occurrences.OrderByDescending(x => x.Value)
                                  .ThenBy(x => x.Key)
                                  .Select(x => x.Key)
                                  .Take(5)
                                  .ToArray());
        }


        public static string GetCheckSum(string input)
        {
            Regex CheckSumMatch = new Regex(@"(?<=\[).+?(?=\])");
            return CheckSumMatch.Match(input).ToString();


        }

        public static string GetRoomId(string input)
        {
            Regex RoomIdMatch = new Regex(@"(\d+)");
            return RoomIdMatch.Match(input).ToString();
        }

    }
    class Program
    {



        static void Main(string[] args)
        {
            int sum = 0;
            string path = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay4\input.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string input = sr.ReadLine();
                if (Solver.ReturnCode(input) == Solver.GetCheckSum(input))
                {
                    sum += Convert.ToInt32(Solver.GetRoomId(input));
                }
            }
            Console.WriteLine(sum);
           
            Console.Read();
        }
    }
}
