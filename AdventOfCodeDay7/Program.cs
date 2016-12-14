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
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 2] && input[i + 1] != input[i + 3]) return true;

            }
            return false;
        }

        public static bool isABA(string input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2] && input[i] != input[i + 1]) return true;

            }
            return false;
        }

        public static List<string> getABA(string input)
        {
            var ABAlist = new List<string>();
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2] && input[i] != input[i + 1]) ABAlist.Add(string.Join("", input[i], input[i + 1], input[i + 2]));

            }

            return ABAlist;
        }

        public static string ABAtoBAB(string input)
        {
            return string.Join("", input[1], input[0], input[1]);
        }


        public static bool isSSL(string input)
        {
            List<string> abas = new List<string>();
            List<string> babs = new List<string>();
            List<string> babs1 = new List<string>();
            string[] ips = input.Split('[', ']');
            for (int i = 0; i < ips.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (isABA(ips[i])) abas.Add(ips[i]);
                }
                babs.Add(ips[i]);
            }
            foreach (var b in babs)
            {
                babs1.Add(ABAtoBAB(b));
            }
            int abaCount = 0;
            foreach (var item in babs1)
            {
                if (babs.Contains(ABAtoBAB(item)))
                {
                    abaCount++;
                }
            }
            if (abaCount == babs.Count - 1) return true;
            else
                return false;
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
            int countSupportingSSl = 0;
            foreach (var line in input)
            {
                if (isSSL(line)) countSupportingSSl++;
            }
            //part1
            //linq credit to user /u/Senoy05
            //didn't know you could do it like this 

            int countSupportingTLS = input
               .Select(i => i.Split('[', ']'))
               .Select(i => new List<IEnumerable<bool>>
               {
                   i.Where((c, a) => a % 2 == 0).Select(a => isAbba(a)),
                   i.Where((c, a) => a % 2 != 0).Select(a => isAbba(a))
               }).Count(i => i[0].Any(a => a) && i[1].All(a => !a));
            //part 2



            Console.WriteLine(countSupportingTLS);
            Console.WriteLine(countSupportingSSl);
            Console.Read();
        }
    }
}
