
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventDays.Day2
{
    public class Borrowed_ProblemDampener
    {
        public void ReadDocument()
        {
            String line;
            List<string[]> input = new();
            try
            {
                StreamReader sr = new StreamReader("C:\\My Repos\\AdventOfCode\\AdventDays\\Day2\\input.txt");
                line = sr.ReadLine() ?? "";

                while (line != null && line != "")
                {
                    if (line is not null)
                    {
                        // Logic here.
                        string[] levels = line.Split(" ");

                        if (line is not null)
                        {
                            // Logic here.
                            input.Add(levels);
                        }

                        line = sr.ReadLine() ?? "";
                    }
                }

                Part2(input);
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            bool IsValidReport(List<int> levels)
            {
                // We don't care about the numbers, just wether going up or down, not both
                var isIncreasing = IsIncreasing(levels);
                var isDecreasing = IsDecreasing(levels);

                if (!isIncreasing && !isDecreasing) return false;

                // Check that all adjacent levels differ by at least 1 and at most 3
                for (var i = 0; i < levels.Count - 1; i++)
                {
                    var diff = Math.Abs(levels[i + 1] - levels[i]);
                    if (diff is < 1 or > 3)
                    {
                        return false;
                    }
                }

                return true;
            }

            bool IsIncreasing(List<int> numbers)
            {
                for (var i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] < numbers[i - 1]) return false;
                }

                return true;
            }

            bool IsDecreasing(List<int> numbers)
            {
                for (var i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] > numbers[i - 1]) return false;
                }

                return true;
            }

            void Part2(List<string[]> input)
            {
                var validReports = 0;

                foreach (var ints in input.Select(report => report.Select(int.Parse).ToList()))
                {
                    // If valid as-is, count it
                    if (IsValidReport(ints))
                    {
                        validReports++;
                        continue;
                    }

                    // Check if removing any single level makes it valid
                    if (ints.Select((t, i) => ints.Where((_, index) => index != i).ToList())
                        .Any(IsValidReport))
                    {
                        validReports++;
                    }
                }

                Console.WriteLine(validReports);
            }
        }
    }
}