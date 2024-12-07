using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc7
{
    internal class aoc7
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            //part1
            long sum = 0;
            long currentsum = 0;
            List<string> operators = new List<string>();
            foreach (string line in lines)
            {
                string[] numbers = line.Split(' ');
                numbers[0] = numbers[0].Substring(0, numbers[0].Length - 1);

                operators.Clear();
                operators = GenerateOperatorCombinations(numbers.Length - 2);

                for (int i = 0; i < operators.Count; i++)
                {
                    currentsum = Convert.ToInt32(numbers[1]);
                    for (int j = 0; j < numbers.Length - 2; j++)
                    {
                        if (operators[i][j] == 'm')
                        {
                            currentsum *= Convert.ToInt32(numbers[j + 2]);
                        }
                        else
                        {
                            currentsum += Convert.ToInt32(numbers[j + 2]);
                        }
                    }
                    if (currentsum == Convert.ToInt64(numbers[0]))
                    {
                        sum += currentsum;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);

            //part2
            sum = 0;
            foreach (string line in lines)
            {
                string[] numbers = line.Split(' ');
                numbers[0] = numbers[0].Substring(0, numbers[0].Length - 1);
                operators.Clear();
                operators = GenerateOperatorCombinationsP2(numbers.Length - 2);

                for (int i = 0; i < operators.Count; i++)
                {
                    currentsum = Convert.ToInt32(numbers[1]);
                    for (int j = 0; j < numbers.Length - 2; j++)
                    {
                        if (operators[i][j] == 'm')
                        {
                            currentsum *= Convert.ToInt32(numbers[j + 2]);
                        }
                        else if (operators[i][j] == 'c')
                        {
                            currentsum = long.Parse(currentsum.ToString() + numbers[j + 2]);
                        }
                        else
                        {
                            currentsum += Convert.ToInt32(numbers[j + 2]);
                        }
                    }
                    if (currentsum == Convert.ToInt64(numbers[0]))
                    {
                        sum += currentsum;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static List<string> GenerateOperatorCombinations(int length)
        {
            List<string> combinations = new List<string>();
            int totalCombinations = 1 << length;

            for (int i = 0; i < totalCombinations; i++)
            {
                char[] combo = new char[length];
                for (int j = 0; j < length; j++)
                {
                    combo[j] = ((i & (1 << j)) != 0) ? 'm' : 'p';
                }
                combinations.Add(new string(combo));
            }

            return combinations;
        }

        static List<string> GenerateOperatorCombinationsP2(int length)
        {

            char[] chars = { 'p', 'm', 'c' };
            int totalCombinations = (int)Math.Pow(chars.Length, length);
            List<string> combinations = new List<string>();
            for (int i = 0; i < totalCombinations; i++)
            {
                string combination = "";
                int index = i;

                for (int j = 0; j < length; j++)
                {
                    combination = chars[index % chars.Length] + combination;
                    index /= chars.Length;
                }
                combinations.Add(combination);
            }
            return combinations;
        }
    }
}
