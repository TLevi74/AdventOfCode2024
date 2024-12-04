using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc4
{
    internal class aoc4
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] lines = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[,] table = new string[lines.Length + 6, lines[0].Length + 6];
            for (int i = 0; i < lines.Length + 6; i++)
            {
                for (int j = 0; j < lines[0].Length + 6; j++)
                {
                    table[i, j] = "0";
                }
            }
            for (int i = 3; i < lines.Length+3; i++)
            {
                for (int j = 3; j < lines[0].Length+3; j++)
                {
                    table[i, j] = lines[i-3][j-3].ToString();
                }
            }
            //part 1
            int sum = 0;
            for(int i = 0; i < lines.Length+6; i++)
            {
                for(int j = 0; j < lines[0].Length+6; j++)
                {
                    if (table[i,j] == "X")
                    {
                        if (table[i-1,j] == "M" && table[i - 2, j] == "A" && table[i - 3, j] == "S")
                        {
                            sum++;
                        }
                        if (table[i + 1, j] == "M" && table[i + 2, j] == "A" && table[i + 3, j] == "S")
                        {
                            sum++;
                        }
                        if (table[i, j-1] == "M" && table[i, j - 2] == "A" && table[i, j - 3] == "S")
                        {
                            sum++;
                        }
                        if (table[i, j + 1] == "M" && table[i, j + 2] == "A" && table[i, j + 3] == "S")
                        {
                            sum++;
                        }
                        if (table[i - 1, j-1] == "M" && table[i - 2, j - 2] == "A" && table[i - 3, j - 3] == "S")
                        {
                            sum++;
                        }
                        if (table[i + 1, j + 1] == "M" && table[i + 2, j + 2] == "A" && table[i + 3, j + 3] == "S")
                        {
                            sum++;
                        }
                        if (table[i - 1, j + 1] == "M" && table[i - 2, j + 2] == "A" && table[i - 3, j + 3] == "S")
                        {
                            sum++;
                        }
                        if (table[i + 1, j - 1] == "M" && table[i + 2, j - 2] == "A" && table[i + 3, j - 3] == "S")
                        {
                            sum++;
                        }
                    }
                }
            }
            Console.WriteLine(sum);

            //part 2
            sum = 0;
            for (int i = 0; i < lines.Length + 6; i++)
            {
                for (int j = 0; j < lines[0].Length + 6; j++)
                {
                    if (table[i,j] == "A")
                    {
                        if (table[i-1, j-1] == "M" && table[i+1, j+1] == "S" && table[i - 1, j + 1] == "M" && table[i + 1, j - 1] == "S")
                        {
                            sum++;
                        }
                        if (table[i - 1, j - 1] == "M" && table[i + 1, j + 1] == "S" && table[i - 1, j + 1] == "S" && table[i + 1, j - 1] == "M")
                        {
                            sum++;
                        }
                        if (table[i - 1, j - 1] == "S" && table[i + 1, j + 1] == "M" && table[i - 1, j + 1] == "M" && table[i + 1, j - 1] == "S")
                        {
                            sum++;
                        }
                        if (table[i - 1, j - 1] == "S" && table[i + 1, j + 1] == "M" && table[i - 1, j + 1] == "S" && table[i + 1, j - 1] == "M")
                        {
                            sum++;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
