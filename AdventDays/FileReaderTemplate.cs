namespace AdventOfCode.AdventDays
{
    public class FileReaderTemplate
    {
        public void ReadDocument()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\My Repos\\AdventOfCode\\AdventDays\\Day1\\input.txt");
                line = sr.ReadLine() ?? "";
                
                while (line != null)
                {
                    Console.WriteLine(line);

                    if (line is not null)
                    {
                        // Logic here.
                    }

                    line = sr.ReadLine() ?? "";
                }

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
