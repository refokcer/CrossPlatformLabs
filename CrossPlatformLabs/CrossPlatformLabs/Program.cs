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
            // Read input numbers from the input file
            List<long> inputNumbers = FileService.ReadInputNumbers(InputFilePath, OutputFilePath);

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
                long count = CountNumbersNotDivisibleBy2_3_5(N);

                // Add the result to the list
                results.Add(count.ToString());
            }

            // Write all results to the output file
            FileService.WriteOutputResults(OutputFilePath, results);
        }

        static long CountNumbersNotDivisibleBy2_3_5(long N)
        {
            // Utilize the inclusion-exclusion principle for efficient computation

            // Counts of numbers divisible by each number
            long countDivBy2 = N / 2;
            long countDivBy3 = N / 3;
            long countDivBy5 = N / 5;

            // Counts of numbers divisible by combinations of numbers
            long countDivBy2And3 = N / Math.Lcm(2, 3);   // LCM of 2 and 3 is 6
            long countDivBy2And5 = N / Math.Lcm(2, 5);   // LCM of 2 and 5 is 10
            long countDivBy3And5 = N / Math.Lcm(3, 5);   // LCM of 3 and 5 is 15

            // Count of numbers divisible by all three numbers
            long countDivBy2And3And5 = N / Math.Lcm(2, Math.Lcm(3, 5)); // LCM of 2, 3, and 5 is 30

            // Total numbers divisible by 2, 3, or 5
            long totalDivisible = countDivBy2 + countDivBy3 + countDivBy5
                                - countDivBy2And3 - countDivBy2And5 - countDivBy3And5
                                + countDivBy2And3And5;

            // Numbers not divisible by 2, 3, or 5
            long count = N - totalDivisible;

            return count;
        }
    }
}
