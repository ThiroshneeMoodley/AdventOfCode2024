using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventDays.Day1
{
    public class FindDistance_Part1
    {
        public void ReadDocument()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\My Repos\\AdventOfCode\\AdventDays\\Day1\\input.txt");
                line = sr.ReadLine() ?? "";
                List<int> column1 = [];
                List<int> column2 = [];

                while (line != null && line != "")
                {
                    Console.WriteLine(line);

                    if (line is not null && line != "")
                    {
                        // Add input data to data type.
                        string[] col = line.Split("   ");
                        column1.Add(Convert.ToInt32(col[0]));
                        column2.Add(Convert.ToInt32(col[1]));
                    }

                    line = sr.ReadLine() ?? "";
                }

                int totalDistance = GetTotalDistance(column1, column2); // actual logic
                Console.WriteLine(totalDistance);
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

        private int GetTotalDistance(List<int> column1, List<int> column2)
        {
            column1.Sort();
            column2.Sort();
            int totalDistance = 0;

            for (int i = 0; i < column1.Count; i++)
            {
                int distance = Math.Abs(column1[i] - column2[i]);
                totalDistance += distance;
            }

            return totalDistance;
        }
    }
}
