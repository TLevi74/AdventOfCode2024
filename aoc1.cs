using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc1
{
    internal class aoc1
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] lines = input.Split('\n');
            List<int> numbers1 = new List<int>();
            List<int> numbers2 = new List<int>();
            // Part 1
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split();
                numbers1.Add(Convert.ToInt32(line[0]));
                numbers2.Add(Convert.ToInt32(line[1]));
            }
            numbers1.Sort();
            numbers2.Sort();
            int sum = 0;
            for (int i = 0; i < numbers1.Count; i++)
            {
                if (numbers1[i] > numbers2[i])
                {
                    sum += numbers1[i] - numbers2[i];
                }
                else
                {
                    sum += numbers2[i] - numbers1[i];
                }
            }
            Console.WriteLine(sum);
            // Part 2
            sum = 0;
            int numbercount = 0;
            for (int i = 0;i < numbers1.Count; i++)
            {
                numbercount = 0;
                for (int j = 0; j < numbers2.Count; j++)
                {
                    if (numbers2[j] == numbers1[i])
                    {
                        numbercount++;
                    }
                }
                sum += numbercount * numbers1[i];
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
