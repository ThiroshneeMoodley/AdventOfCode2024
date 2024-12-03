using System.Linq;

namespace AdventOfCode.AdventDays.Day1
{
    public class FindDistance_Part2
    {
        public void ReadDocument()
        {
            System.String line;
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

                int totalDistance = GetSimilarityScore(column1, column2); // actual logic
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

        private int GetSimilarityScore(List<int> column1, List<int> column2)
        {
            column1.Sort();
            column2.Sort();

            Dictionary<int, int> column1Counter = []; // <number, number count>
            Dictionary<int, int> column2Counter = []; // <number, number count>

            int similarityScore = 0;

            column1Counter = GetNumberCounter(column1, column1Counter);
            column2Counter = GetNumberCounter(column2, column2Counter);

            similarityScore = column1Counter.Keys
            .Intersect(column2Counter.Keys)
            .Sum(key => key * column1Counter[key] * column2Counter[key]);

            return similarityScore;
        }

        private static Dictionary<int, int> GetNumberCounter(List<int> column, Dictionary<int, int> columnCounter)
        {
            for (int i = 0; i < column.Count; i++)
            {
                if (column[i] != -1)
                {
                    columnCounter.Add(column[i], 1);
                    for (int j = i + 1; j < column.Count - 1; j++)
                    {
                        if (column[i] == column[j] && i != j)
                        {
                            columnCounter[column[i]]++;
                            column[j] = -1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return columnCounter;
        }
    }
}
