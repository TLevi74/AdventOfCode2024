using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc5
{
    internal class aoc5
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");

            List<List<string>> numbers = new List<List<string>>();
            int upgradesstart = 0;
            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    upgradesstart = i + 1;
                    break;
                }
                numbers.Add(lines[i].Split('|').ToList());
            }

            string[] upgrades = new string[lines.Length - upgradesstart];
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = lines[i + upgradesstart];
            }
            //Part 1
            int sum = 0;
            bool found = false;
            for(int i = 0; i < upgrades.Length; i++)
            {
                string[] currentupgrade = upgrades[i].Split(',');
                found = false;
                for (int j = 1; j < currentupgrade.Length; j++)
                {
                    if (found)
                    {
                        break;
                    }
                    for (int k = 0; k < j; k++)
                    {
                        if (numbers.Any(l => l.SequenceEqual(new List<string> { currentupgrade[j], currentupgrade[k] })))
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    sum += Convert.ToInt32(currentupgrade[currentupgrade.Length/2]);
                }
            }
            Console.WriteLine(sum);

            //Part 2
            sum = 0;
            for (int i = 0; i < upgrades.Length; i++)
            {
                string[] currentupgrade = upgrades[i].Split(',');
                for (int j = 1; j < currentupgrade.Length; j++)
                {
                    for (int k = 0; k < j; k++)
                    {
                        if (numbers.Any(l => l.SequenceEqual(new List<string> { currentupgrade[j], currentupgrade[k] })))
                        {
                            string temp = currentupgrade[j];
                            currentupgrade[j] = currentupgrade[k];
                            currentupgrade[k] = temp;
                            sum += Findproblem(currentupgrade, numbers);
                        }
                    }
                }
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
        static int Findproblem(string[] currentupgrade, List<List<string>> numbers)
        {
            for (int j = 1; j < currentupgrade.Length; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    if (numbers.Any(l => l.SequenceEqual(new List<string> { currentupgrade[j], currentupgrade[k] })))
                    {
                        string temp = currentupgrade[j];
                        currentupgrade[j] = currentupgrade[k];
                        currentupgrade[k] = temp;
                        return Findproblem(currentupgrade, numbers);
                    }
                }
            }
            return Convert.ToInt32(currentupgrade[currentupgrade.Length / 2]);
        }
    }
}
