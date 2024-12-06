using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    string? currentLine = sr.ReadLine();

                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        reports.Add(currentLine
                        .Split(' ')
                        .Select(item => Int32.Parse(item))
                        .ToList());
                    }
                }
            }

            foreach (List<int> report in reports)
            {
                if (IsSafe(report))
                {
                    ++counter;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        List<int> reportCopy = report.ToList();
                        reportCopy.RemoveAt(i);

                        if (IsSafe(reportCopy))
                        {
                            ++counter;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }

        public static bool IsSafe(List<int> line)
        {
            bool increment = line[0] > line[1];

            for (int i = 0; i < line.Count - 1; i++)
            {
                int diff = line[i] - line[i + 1];

                if (increment && (diff < 1 || diff > 3))
                {
                    return false;
                }
                else if(!increment && (diff < -3 || diff > -1))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
