namespace AdventOfCode.AdventDays.Day2
{
    public class ProblemDampener_Part2
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
                    if (line is not null)
                    {
                        // Logic here.
                        string[] levels = line.Split(" ");
                        bool? isIncreasing = null;

                        for (int i = 0; i < levels.Length - 1; i++)
                        {
                            int firstLevel = Convert.ToInt32(levels[i]);
                            int secondLevel = Convert.ToInt32(levels[i + 1]);

                            // decide if levels in report are increasing or decreasing.
                            // every subsequent difference needs to match the pattern.

                            isIncreasing ??= firstLevel < secondLevel;

                            if (isIncreasing == null) // first iteration - decide on pattern
                            {
                                isIncreasing = secondLevel > firstLevel;
                            }
                            else if (DoesPatternMatch(isIncreasing, firstLevel, secondLevel)) // ensure each iteration matches the pattern
                            {
                                if (Math.Abs(firstLevel - secondLevel) > 3 || firstLevel == secondLevel)
                                {
                                    // re-do pattern check.
                                    // re-do pattern check.

                                    int newFirstLevel = 0;
                                    int newSecondLevel = 0;

                                    if (i != 0)
                                    {
                                        newFirstLevel = Convert.ToInt32(levels[i - 1]);
                                    }
                                    if (i != levels.Length)
                                    {
                                        newSecondLevel = Convert.ToInt32(levels[i + 1]);
                                    }


                                    if (Math.Abs(newFirstLevel - newSecondLevel) > 3 || newFirstLevel == secondLevel)
                                    {
                                        Console.WriteLine(line + " is unsafe");
                                        break;
                                    }
                                    else if (Math.Abs(newFirstLevel - newSecondLevel) <= 3 && levels.Length - 1 == i + 1)
                                    {
                                        Console.WriteLine(line + " is safe");
                                        safetyCounter++;
                                    }
                                }
                                else if (Math.Abs(firstLevel - secondLevel) <= 3 && levels.Length - 1 == i + 1)
                                {
                                    Console.WriteLine(line + " is safe");
                                    safetyCounter++;
                                }
                            }
                            else
                            {
                                // re-do pattern check.

                                int newFirstLevel = 0;
                                int newSecondLevel = 0;

                                if (i != 0)
                                {
                                    newFirstLevel = Convert.ToInt32(levels[i - 1]);
                                }
                                if (i != levels.Length)
                                {
                                    newSecondLevel = Convert.ToInt32(levels[i + 1]);
                                }

                                if (Math.Abs(newFirstLevel - newSecondLevel) > 3 || newFirstLevel == newSecondLevel)
                                {
                                    Console.WriteLine(line + " is unsafe");
                                    break;
                                }
                                else if (Math.Abs(newFirstLevel - newSecondLevel) <= 3 && levels.Length - 1 == i + 1)
                                {
                                    Console.WriteLine(line + " is safe");
                                    safetyCounter++;
                                }
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

        private static bool DoesPatternMatch(bool? isIncreasing, int firstLevel, int secondLevel)
        {
            return isIncreasing == secondLevel > firstLevel;
        }
    }
}
