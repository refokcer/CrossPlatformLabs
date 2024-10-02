namespace Lab1;

public class FileService
{
    // Constants for file paths
    private readonly string InputFilePath;
    private readonly string OutputFilePath;

    public FileService(string InputFilePath, string OutputFilePath)
    {
        this.InputFilePath = InputFilePath;
        this.OutputFilePath = OutputFilePath;
    }

    public List<long>? ReadInputNumbers()
    {
        List<long> numbers = [];

        try
        {
            using (StreamReader reader = new StreamReader(InputFilePath))
            {
                string line;
                int lineNumber = 1;

                // Read each line until the end of the file

                while ((line = reader.ReadLine()!) != null)
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
                        return null;
                    }
                    Console.WriteLine($"Line number {lineNumber} is read");
                    lineNumber++;
                }
                Console.WriteLine("Finished reading all input data line by line");
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

    public void WriteOutputResults(IEnumerable<string> results)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(OutputFilePath))
            {
                // Write each result on a new line
                Console.WriteLine("The recording of the answer file has started");
                foreach (string result in results)
                {
                    writer.WriteLine(result);
                }
                Console.WriteLine("Finished writing the answer file");
            }
        }
        catch (Exception ex)
        {
            // Output error to console if writing fails
            Console.WriteLine("Error writing output file: " + ex.Message);
        }
    }
}
