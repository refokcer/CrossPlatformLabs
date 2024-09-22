namespace CrossPlatformLabs
{
    public static class FileService
    {
        public static List<long> ReadInputNumbers(string InputFilePath, string OutputFilePath)
        {
            List<long> numbers = [];

            try
            {
                using (StreamReader reader = new StreamReader(InputFilePath))
                {
                    string line;
                    int lineNumber = 1;

                    // Read each line until the end of the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Try to parse the line as a long integer
                        if (long.TryParse(line.Trim(), out long N))
                        {
                            numbers.Add(N);
                        }
                        else
                        {
                            // Write error message and return null
                            Utils.WriteError(OutputFilePath, $"Error: Line {lineNumber} in INPUT.txt is not a valid integer.");
                            lineNumber--;
                            //return null;
                        }
                        lineNumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions during file reading
                Utils.WriteError(OutputFilePath, "Error reading input file: " + ex.Message);
                return null;
            }

            return numbers;
        }

        public static void WriteOutputResults(string OutputFilePath, IEnumerable<string> results)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(OutputFilePath))
                {
                    // Write each result on a new line
                    foreach (string result in results)
                    {
                        writer.WriteLine(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Output error to console if writing fails
                Console.WriteLine("Error writing output file: " + ex.Message);
            }
        }
    }
}
