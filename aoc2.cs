using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace aoc2
{
    class aoc2
    {
        static void Main(string[] args)
        {
            string[] line;
            int[] intline;
            int sum = 0;
            //PART 1
            StreamReader sr = new StreamReader("input.txt");
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().Split();
                intline = new int[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    intline[i] = Convert.ToInt32(line[i]);
                }
                int[] sortedline = new int[line.Length];
                Array.Copy(intline, sortedline, intline.Length);
                Array.Sort(sortedline);
                if (intline.SequenceEqual(sortedline))
                {
                    bool addsum = true;
                    for (int i = 1; i < intline.Length; i++)
                    {
                        if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                        {
                            addsum = false;
                            break;
                        }
                    }
                    if (addsum)
                    {
                        sum++;
                    }
                }
                else if (intline.SequenceEqual(sortedline.Reverse()))
                {
                    bool addsum = true;
                    for (int i = 1; i < intline.Length; i++)
                    {
                        if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                        {
                            addsum = false;
                            break;
                        }
                    }
                    if (addsum)
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);

            //PART 2
            sum = 0;
            StreamReader sr2 = new StreamReader("input.txt");
            while (!sr2.EndOfStream)
            {
                line = sr2.ReadLine().Split();
                intline = new int[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    intline[i] = Convert.ToInt32(line[i]);
                }
                int[] sortedline2 = new int[line.Length];
                Array.Copy(intline, sortedline2, intline.Length);
                Array.Sort(sortedline2);
                if (intline.SequenceEqual(sortedline2))
                {
                    bool addsum = true;
                    for (int i = 1; i < intline.Length; i++)
                    {
                        if (!(sortedline2[i] - sortedline2[i - 1] >= 1 && sortedline2[i] - sortedline2[i - 1] <= 3))
                        {
                            addsum = false;
                        }
                    }
                    if (addsum)
                    {
                        sum++;
                    }else
                    {
                        for (int j = 0; j < intline.Length; j++)
                        {
                            var missingline = intline.Where((val, index) => index != j).ToArray();
                            int[] sortedline = new int[missingline.Count()];
                            Array.Copy(missingline, sortedline, missingline.Length);
                            Array.Sort(sortedline);
                            if (missingline.SequenceEqual(sortedline))
                            {
                                bool addsum2 = true;
                                for (int i = 1; i < missingline.Count(); i++)
                                {
                                    if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                    {
                                        addsum2 = false;
                                        break;
                                    }
                                }
                                if (addsum2)
                                {
                                    sum++;
                                    break;
                                }
                            }
                            else if (missingline.SequenceEqual(sortedline.Reverse()))
                            {
                                bool addsum2 = true;
                                for (int i = 1; i < missingline.Count(); i++)
                                {
                                    if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                    {
                                        addsum2 = false;
                                        break;
                                    }
                                }
                                if (addsum2)
                                {
                                    sum++;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (intline.SequenceEqual(sortedline2.Reverse()))
                {
                    bool addsum2 = true;
                    for (int i = 1; i < intline.Length; i++)
                    {
                        if (!(sortedline2[i] - sortedline2[i - 1] >= 1 && sortedline2[i] - sortedline2[i - 1] <= 3))
                        {
                            addsum2 = false;
                        }
                    }
                    if (addsum2)
                    {
                        sum++;
                    }else
                    {
                        for (int j = 0; j < intline.Length; j++)
                        {
                            var missingline = intline.Where((val, index) => index != j).ToArray();
                            int[] sortedline = new int[missingline.Count()];
                            Array.Copy(missingline, sortedline, missingline.Length);
                            Array.Sort(sortedline);
                            if (missingline.SequenceEqual(sortedline))
                            {
                                addsum2 = true;
                                for (int i = 1; i < missingline.Count(); i++)
                                {
                                    if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                    {
                                        addsum2 = false;
                                        break;
                                    }
                                }
                                if (addsum2)
                                {
                                    sum++;
                                    break;
                                }
                            }
                            else if (missingline.SequenceEqual(sortedline.Reverse()))
                            {
                                addsum2 = true;
                                for (int i = 1; i < missingline.Count(); i++)
                                {
                                    if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                    {
                                        addsum2 = false;
                                        break;
                                    }
                                }
                                if (addsum2)
                                {
                                    sum++;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < intline.Length; j++)
                    {
                        var missingline = intline.Where((val, index) => index != j).ToArray();
                        int[] sortedline = new int[missingline.Count()];
                        Array.Copy(missingline, sortedline, missingline.Length);
                        Array.Sort(sortedline);
                        if (missingline.SequenceEqual(sortedline))
                        {
                            bool addsum2 = true;
                            for (int i = 1; i < missingline.Count(); i++)
                            {
                                if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                {
                                    addsum2 = false;
                                    break;
                                }
                            }
                            if (addsum2)
                            {
                                sum++;
                                break;
                            }
                        }
                        else if (missingline.SequenceEqual(sortedline.Reverse()))
                        {
                            bool addsum2 = true;
                            for (int i = 1; i < missingline.Count(); i++)
                            {
                                if (!(sortedline[i] - sortedline[i - 1] >= 1 && sortedline[i] - sortedline[i - 1] <= 3))
                                {
                                    addsum2 = false;
                                    break;
                                }
                            }
                            if (addsum2)
                            {
                                sum++;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
