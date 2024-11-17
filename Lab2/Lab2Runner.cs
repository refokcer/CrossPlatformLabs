namespace Lab2;

public class Lab2Runner
{
    public void Run(string InputFilePath, string OutputFilePath)
    {
        try
        {
            // Initializing file and math services
            Console.WriteLine("Initializing services...");
            var fileService = new FileService(InputFilePath, OutputFilePath);

            // Reading input data from the file
            Console.WriteLine("Reading input data...");
            List<string[]> wordSets = fileService.ReadInputFile();

            // Processing word sets
            Console.WriteLine("Processing word sets...");
            List<int> results = ProcessInput(wordSets);

            // Writing the results to the output file
            Console.WriteLine("Writing results to the output...");
            fileService.WriteOutputFile(results);

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            // Catching and showing any errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public List<int> ProcessInput(List<string[]> wordSets)
    {
        var results = new List<int>();

        foreach (var words in wordSets)
        {
            Console.WriteLine("Calculating maximum chain length...");
            int maxLength = MathService.CalculateMaxLength(words);
            results.Add(maxLength);
        }

        return results;
    }

    public List<string[]> ConvertToLongStringList(List<string> input)
    {
        var result = new List<string[]>();
        int i = 0;

        while (i < input.Count)
        {
            if (int.TryParse(input[i], out int wordCount))
            {
                if (i + wordCount > input.Count)
                {
                    Console.WriteLine($"Warning: Not enough words for the specified count at line {i + 1}. Skipping.");
                    break;
                }

                var words = input.Skip(i + 1).Take(wordCount).ToArray();
                result.Add(words);

                i += wordCount + 1;
            }
            else
            {
                Console.WriteLine($"Warning: Invalid word count at line {i + 1}: '{input[i]}'. Skipping.");
                i++;
            }
        }

        return result;
    }
}
