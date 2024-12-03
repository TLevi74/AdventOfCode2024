using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace aoc3
{
    internal class aoc3
    {
        static void Main(string[] args)
        {
            //part 1
            string input = System.IO.File.ReadAllText("input.txt");
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    string parttofind = "mul(" + i.ToString() + "," + j.ToString() + ")";
                    sum += (Regex.Matches(input, Regex.Escape(parttofind)).Count * i * j);
                }
            }
            Console.WriteLine(sum);

            //part 2
            sum = 0;

            //!!!!
            string pattern = @"don't\(\).*?do\(\)";
            input = Regex.Replace(input, pattern, "", RegexOptions.Singleline);
            //!!!!

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    string parttofind = "mul(" + i.ToString() + "," + j.ToString() + ")";
                    sum += (Regex.Matches(input, Regex.Escape(parttofind)).Count * i * j);
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
