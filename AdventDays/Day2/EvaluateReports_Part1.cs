using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventDays.Day2
{
    public class EvaluateReports_Part1
    {
        public void ReadDocument()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\My Repos\\AdventOfCode\\AdventDays\\Day2\\input.txt");
                line = sr.ReadLine() ?? "";
                int safetyCounter = 0;

                while (line != null && line != "")
                {
                    Console.WriteLine(line);

                    if (line is not null)
                    {
                        // Logic here.
                        string[] levels = line.Split(" ");
                        bool? isIncreasing = null;

                        for (int i = 0; i < levels.Length - 1; i++)
                        {
                            int firstLevel = Convert.ToInt32(levels[i]);
                            int secondLevel = Convert.ToInt32(levels[i+1]);

                            // decide if levels in report are increasing or decreasing.
                            // every subsequent difference needs to match the pattern.

                            isIncreasing ??= firstLevel < secondLevel;

                            if (isIncreasing == null) // first iteration - decide on pattern
                            {
                                isIncreasing = secondLevel > firstLevel;
                            }
                            else if (isIncreasing == secondLevel > firstLevel) // ensure each iteration matches the pattern
                            {
                                if (Math.Abs(firstLevel - secondLevel) > 3 || firstLevel == secondLevel)
                                {
                                    break;
                                }
                                else if (Math.Abs(firstLevel - secondLevel) <= 3 && levels.Length - 1 == i + 1)
                                {
                                    safetyCounter++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    line = sr.ReadLine() ?? "";
                }

                Console.WriteLine(safetyCounter);
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
        }
    }
}
