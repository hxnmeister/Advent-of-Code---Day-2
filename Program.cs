using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code___Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_PATH = @"G:\Visual Studio Projects\Advent of Code - Day 2\input.txt";

            int counter = 0;

            List<List<int>> reports = new List<List<int>>();

            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                while (!sr.EndOfStream)
                {
                    reports.Add(sr.ReadLine()
                        .Split(' ')
                        .Select(item => Int32.Parse(item))
                        .ToList());
                }
            }

            foreach (var report in reports)
            {
                bool? isIncrease = null;
                bool isSafe = true;

                for (int j = 1, m = 0; j < report.Count && m <= report.Count; j++, m++)
                {
                    int diff = report[m] - report[j];
                    int abs = Math.Abs(diff);

                    if ((abs < 1 || abs > 3))
                    {
                        isSafe = false;
                        break;
                    }
                    else if (isIncrease == null)
                    {
                        isIncrease = diff < 0;
                    }
                    else if (isIncrease.Value && diff > 0 ||  !isIncrease.Value && diff < 0)
                    {
                        isSafe = false;
                        break;
                    }
                }

                if (isSafe) ++counter;
            }

            Console.WriteLine(counter);
        }
    }
}
