using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace aoc6
{
    internal class aoc6
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");
            string[,] map = new string[lines.Length+2, lines[0].Length+2];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "Y";
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i+1, j+1] = lines[i][j].ToString();
                }
            }
            // Part 1
            int posi = 0;
            int posj = 0;
            string nextstep = ".";
            string facing = "N";
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == "^")
                    {
                        posi = i;
                        posj = j;
                        break;
                    }
                }
            }

            while (nextstep != "Y")
            {
                switch (facing)
                {
                    case "N":
                        if (map[posi-1, posj] != "#")
                        {
                            map[posi, posj] = "X";
                            posi--;
                        }
                        else
                        {
                            facing = "E";
                        }
                        nextstep = map[posi - 1, posj];
                        break;
                    case "E":
                        if (map[posi, posj + 1] != "#")
                        {
                            map[posi, posj] = "X";
                            posj++;
                        }
                        else
                        {
                            facing = "S";
                        }
                        nextstep = map[posi, posj + 1];
                        break;
                    case "S":
                        if (map[posi+1, posj] != "#")
                        {
                            map[posi, posj] = "X";
                            posi++;
                        }
                        else
                        {
                            facing = "W";
                        }
                        nextstep = map[posi + 1, posj];
                        break;
                    case "W":
                        if (map[posi, posj-1] != "#")
                        {
                            map[posi, posj] = "X";
                            posj--;
                        }
                        else
                        {
                            facing = "N";
                        }
                        nextstep = map[posi, posj - 1];
                        break;
                }
            }
            map[posi, posj] = "X";

            int sum = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == "X")
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);

            // Part 2

            sum = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    for (int k = 0; k < map.GetLength(0); k++)
                    {
                        for (int l = 0; l < map.GetLength(1); l++)
                        {
                            map[k, l] = "Y";
                        }
                    }
                    for (int k = 0; k < lines.Length; k++)
                    {
                        for (int l = 0; l < lines[k].Length; l++)
                        {
                            map[k + 1, l + 1] = lines[k][l].ToString();
                        }
                    }
                    map[i,j] = "#";
                    nextstep = ".";
                    facing = "N";
                    for (int k = 0; k < map.GetLength(0); k++)
                    {
                        for (int l = 0; l < map.GetLength(1); l++)
                        {
                            if (map[k, l] == "^")
                            {
                                posi = k;
                                posj = l;
                                break;
                            }
                        }
                    }
                    bool found = false;
                    while (nextstep != "Y")
                    {
                        if (found)
                        {
                            sum++;
                            break;  
                        }
                        switch (facing)
                        {
                            case "N":
                                if (map[posi - 1, posj] != "#")
                                {
                                    if (map[posi, posj] == "N")
                                    {
                                        found = true;
                                    }
                                    map[posi, posj] = "N";
                                    posi--;
                                }
                                else
                                {
                                    facing = "E";
                                }
                                nextstep = map[posi - 1, posj];
                                break;
                            case "E":
                                if (map[posi, posj + 1] != "#")
                                {
                                    if (map[posi, posj] == "E")
                                    {
                                        found = true;
                                    }
                                    map[posi, posj] = "E";
                                    posj++;
                                }
                                else
                                {
                                    facing = "S";
                                }
                                nextstep = map[posi, posj + 1];
                                break;
                            case "S":
                                if (map[posi + 1, posj] != "#")
                                {
                                    if (map[posi, posj] == "S")
                                    {
                                        found = true;
                                    }
                                    map[posi, posj] = "S";
                                    posi++;
                                }
                                else
                                {
                                    facing = "W";
                                }
                                nextstep = map[posi + 1, posj];
                                break;
                            case "W":
                                if (map[posi, posj - 1] != "#")
                                {
                                    if (map[posi, posj] == "W")
                                    {
                                        found = true;
                                    }
                                    map[posi, posj] = "W";
                                    posj--;
                                }
                                else
                                {
                                    facing = "N";
                                }
                                nextstep = map[posi, posj - 1];
                                break;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
