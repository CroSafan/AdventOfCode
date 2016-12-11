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

        public static string GetRoomName(string input)
        {
            Regex RoomNameMatch = new Regex(@"^[A-z-]+");
            return RoomNameMatch.Match(input).ToString();

        }

        public static string DecryptCode(string input, string id)
        {
            //almost gone crazy, so i gave up
            //https://github.com/StefanPahlplatz/AdventOfCode/blob/master/Day%204%20Part%202/Day%204%20Part%202/Room.cs

            int SectorId = Convert.ToInt32(id);
            List<char> decryptedchar = new List<char>();

            // Loop through the name
            for (int i = 0; i < input.Length; i++)
            {
                // Replace - with a space
                if (input[i] == '-')
                {
                    decryptedchar.Add(' ');
                }
                else
                {
                    // Get the int value of the current char
                    int temp = input[i];

                    // Increment with the sector id
                    for (int j = 0; j < SectorId; j++)
                    {
                        temp++;
                        if (temp > 122)     // Ascii value for z
                            temp = 97;      // Ascii value for a
                    }

                    // Add the decrypted char
                    decryptedchar.Add(Convert.ToChar(temp));
                }
            }

            // Full decrypted string
            string decrypted = "";
            foreach (char c in decryptedchar) { decrypted += c; }

            return decrypted;
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
                if (Solver.DecryptCode(Solver.GetRoomName(input), Solver.GetRoomId(input)).Contains("nort"))
                {
                    Console.WriteLine(Solver.DecryptCode(Solver.GetRoomName(input), Solver.GetRoomId(input)));
                    Console.WriteLine(Solver.GetRoomId(input));

                }
            }


            Console.WriteLine(sum);

            //Console.WriteLine(Solver.DecryptCode(Solver.GetRoomName("qzmt-zixmtkozy-ivhz-343")));
            Console.Read();
        }
    }
}
