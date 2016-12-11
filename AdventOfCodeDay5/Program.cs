using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCodeDay5
{
    internal class Program
    {
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private static void Main(string[] args)
        {
            string input = "abc";

            int index = 3231900;
            string[] code = { "*", "*", "*", "*", "*", "*", "*", "*" };

            string inputHash = "";
            List<int> positions = new List<int>();
            int counter = 0;
            using (MD5 md5Hash = MD5.Create())
            {
                while (code.Contains("*"))
                {
                    inputHash = input + index.ToString();
                    string hash = GetMd5Hash(md5Hash, inputHash);
                    string fiveDigit = hash.Substring(0, 5);
                    int position;
                    // = Convert.ToInt32(hash[5].ToString());
                    bool parsed = Int32.TryParse(hash[5].ToString(), out position);

                    if (fiveDigit == "00000" && parsed)
                    {
                        if (positions.Contains(position) && position < 8 && position >= 0)
                        {
                            index++;
                            break;
                        }
                        else if (position < 8 && position >= 0)
                        {
                            positions.Add(position);
                            code[position] = hash[6].ToString();
                            index++;
                            Console.WriteLine(hash);
                            counter++;
                            if (counter == 6) break;
                        }
                    }
                    index++;
                }
            }
            var nekaj = "";
            foreach (var codeChar in code)
            {
                nekaj += codeChar;
            }
            Console.WriteLine(nekaj);
            Console.Read();
        }
    }
}