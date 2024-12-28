using System.Text.RegularExpressions;

namespace AdventOfCode.AdventDays.Day3
{
    public class MultiplyCorruptTextFile
    {
        public void ReadDocument()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\My Repos\\AdventOfCode\\AdventDays\\Day3\\input.txt");
                line = sr.ReadLine() ?? "";
                int puzzleAnswer = 0;

                while (line != null && line != "")
                {
                    Console.WriteLine(line);

                    if (line is not null)
                    {
                        // Logic here.
                        int value = GetMultipliedValue(line);
                        puzzleAnswer += value;
                    }

                    line = sr.ReadLine() ?? "";
                }

                Console.WriteLine("puzzle answer: " + puzzleAnswer);
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

        public int GetMultipliedValue(string line)
        {
            int puzzleAnswerForLine = 0;
            bool enabled = true;
            string flagPattern = @"(?:do\(\)|don't\(\)).*?mul\(\d{1,3},\d{1,3}\)|mul\(\d{1,3},\d{1,3}\)";
            Regex flatPattern = new Regex(flagPattern);
            MatchCollection flagMatches = flatPattern.Matches(line);

            // Display matches
            foreach (Match match in flagMatches)
            {
                if (match.ToString().StartsWith("mul"))
                {
                    if (enabled)
                    {
                        puzzleAnswerForLine = GetPuzzleAnswerPerMatch(puzzleAnswerForLine, match);
                    }
                }

                else if (match.ToString().StartsWith("don't()"))
                {
                    enabled = false;
                }
                else if (match.ToString().StartsWith("do()"))
                {
                    enabled = true;

                    // new pattern match
                    string newPattern = @"mul\(\d{1,3},\d{1,3}\)";
                    Regex newRegex = new Regex(newPattern);
                    Match newMatch = newRegex.Match(match.ToString());
                    puzzleAnswerForLine = GetPuzzleAnswerPerMatch(puzzleAnswerForLine, newMatch);
                }
            }

            return puzzleAnswerForLine;
        }

        private static int GetPuzzleAnswerPerMatch(int puzzleAnswerForLine, Match newMatch)
        {
            int firstBracketIndex = newMatch.Value.IndexOf("(");
            int secondBracketIndex = newMatch.Value.IndexOf(")");
            int comma = newMatch.Value.IndexOf(",");
            int firstValue = Convert.ToInt32(newMatch.Value.Substring(firstBracketIndex + 1, comma - firstBracketIndex - 1));
            int secondValue = Convert.ToInt32(newMatch.Value.Substring(comma + 1, secondBracketIndex - comma - 1));

            puzzleAnswerForLine += firstValue * secondValue;
            return puzzleAnswerForLine;
        }
    }
}