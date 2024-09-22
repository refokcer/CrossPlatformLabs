using System;
using System.Collections.Generic;
using System.IO;

namespace CrossPlatformLabs
{
    internal class Program
    {
        // Constants for file paths
        private const string InputFilePath = "..//..//..//Files/INPUT.txt";
        private const string OutputFilePath = "..//..//..//Files/OUTPUT.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Reading data from a file");

            // Read input numbers from the input file
            var fileService = new FileService(InputFilePath, OutputFilePath);
            List<long> inputNumbers = fileService.ReadInputNumbers();

            // If reading failed, exit the program
            Console.WriteLine("Checking if the input holes exist");
            if (inputNumbers == null)
            {
                // Error has already been handled
                return;
            }

            // List to store results for each input number
            List<string> results = new List<string>();


            // Process each input number
            Console.WriteLine("Go through all input data one by one");
            for(var i = 0 ; i < inputNumbers.Count; i++)
            {
                var N = inputNumbers[i];

                // Validate the input number
                Console.WriteLine($"Check the range of the {i+1} number");
                if (N < 1 || N > 109)
                {
                    Console.WriteLine($"Error: Invalid value of {i+1} number. It should be in the range frpm 1 to 109");
                    results.Add($"Error: Invalid value of {i+1} number. It should be in the range 1 ≤ N ≤ 109.");
                    continue;
                }

                // Calculate the count of numbers not divisible by 2, 3, or 5
                Console.WriteLine($"Calculate the count of numbers not divisible by 2, 3, or 5 for {i+1} number");
                long count = Math.CountNumbersNotDivisibleBy2_3_5(N);

                // Add the result to the list
                Console.WriteLine($"Add the result for {i+1} number to the list");
                results.Add(count.ToString());
            }

            // Write all results to the output file
            Console.WriteLine("Write everything to a file for output ");
            fileService.WriteOutputResults(results);
        }
    }
}
