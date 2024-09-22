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
            if (inputNumbers == null)
            {
                // Error has already been handled
                return;
            }

            // List to store results for each input number
            List<string> results = new List<string>();

            // Process each input number
            foreach (long N in inputNumbers)
            {
                // Validate the input number
                if (N < 1 || N > 109)
                {
                    results.Add("Error: Invalid value of N. It should be in the range 1 ≤ N ≤ 109.");
                    continue;
                }

                // Calculate the count of numbers not divisible by 2, 3, or 5
                long count = Math.CountNumbersNotDivisibleBy2_3_5(N);

                // Add the result to the list
                results.Add(count.ToString());
            }

            // Write all results to the output file
            fileService.WriteOutputResults(results);
        }
    }
}
