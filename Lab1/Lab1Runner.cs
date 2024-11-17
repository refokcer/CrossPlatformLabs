namespace Lab1;

public class Lab1Runner
{
    public void Run(string InputFilePath, string OutputFilePath)
    {
        Console.WriteLine("Reading data from a file");

        // Read input numbers from the input file
        var fileService = new FileService(InputFilePath, OutputFilePath);
        List<long> inputNumbers = fileService.ReadInputNumbers()!;

        // If reading failed, exit the program
        Console.WriteLine("Checking if the input holes exist");
        if (inputNumbers == null)
        {
            // Error has already been handled
            return;
        }

        // Process input numbers and get results
        Console.WriteLine("Processing input data");
        List<string> results = ProcessInput(inputNumbers);

        // Write all results to the output file
        Console.WriteLine("Write everything to a file for output");
        fileService.WriteOutputResults(results);
    }

    public List<string> ProcessInput(List<long> inputNumbers)
    {
        // List to store results for each input number
        List<string> results = new List<string>();

        // Process each input number
        Console.WriteLine("Go through all input data one by one");
        for (var i = 0; i < inputNumbers.Count; i++)
        {
            var N = inputNumbers[i];

            // Validate the input number
            Console.WriteLine($"Check the range of the {i + 1} number");
            if (N < 1 || N > 109)
            {
                Console.WriteLine($"Invalid value of {i + 1} number. It should be in the range from 1 to 109");
                results.Add($"Invalid value of {i + 1} number. It should be in the range 1 ≤ N ≤ 109.");
                continue;
            }

            // Calculate the count of numbers not divisible by 2, 3, or 5
            Console.WriteLine($"Calculate the count of numbers not divisible by 2, 3, or 5 for {i + 1} number");
            long count = Math.CountNumbersNotDivisibleBy2_3_5(N);

            // Add the result to the list
            Console.WriteLine($"Add the result for {i + 1} number to the list");
            results.Add(count.ToString());
        }

        return results;
    }


    public List<long> ConvertToLongList(List<string> inputStrings)
    {
        var result = new List<long>();

        foreach (var str in inputStrings)
        {
            if (long.TryParse(str, out long number))
            {
                result.Add(number);
            }
            else
            {
                Console.WriteLine($"Warning: '{str}' is not a valid number and will be skipped.");
            }
        }
        return result;
    }
}

