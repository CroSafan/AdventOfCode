using System;
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
            string input = "ojvtpuvg";

            int index = 0;
            int count = 0;
            string code = "";
            string inputHash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                while (count < 8)
                {
                    inputHash = input + index.ToString();
                    string hash = GetMd5Hash(md5Hash, inputHash);
                    string fiveDigit = hash.Substring(0, 5);
                    if (fiveDigit == "00000")
                    {
                        Console.WriteLine(hash);
                        code += hash[5];
                        count++;
                    }
                    index++;
                }
            }
            Console.WriteLine(code);
            Console.Read();
        }
    }
}