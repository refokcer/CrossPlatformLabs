﻿namespace Lab2;

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
            var results = new List<int>();

            // Processing each word set
            foreach (var words in wordSets)
            {
                Console.WriteLine("Calculating maximum chain length...");
                int maxLength = MathService.CalculateMaxLength(words);
                results.Add(maxLength);
            }

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
}
