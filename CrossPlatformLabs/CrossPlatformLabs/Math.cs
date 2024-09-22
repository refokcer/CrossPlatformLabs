using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformLabs
{
    public static class Math
    {
        public static long Lcm(long a, long b)
        {
            return (a * b) / Gcd(a, b);
        }

        public static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long CountNumbersNotDivisibleBy2_3_5(long N)
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
