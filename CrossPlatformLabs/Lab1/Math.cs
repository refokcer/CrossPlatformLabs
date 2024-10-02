namespace Lab1;

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
        // Counts of numbers divisible by each number
        long countDivBy2 = N / 2;
        long countDivBy3 = N / 3;
        long countDivBy5 = N / 5;

        // Counts of numbers divisible by combinations of numbers
        long countDivBy2And3 = N / Math.Lcm(2, 3);
        long countDivBy2And5 = N / Math.Lcm(2, 5);
        long countDivBy3And5 = N / Math.Lcm(3, 5);

        // Count of numbers divisible by all three numbers
        long countDivBy2And3And5 = N / Math.Lcm(2, Math.Lcm(3, 5));

        // Total numbers divisible by 2, 3, or 5
        long totalDivisible = countDivBy2 + countDivBy3 + countDivBy5
                            - countDivBy2And3 - countDivBy2And5 - countDivBy3And5
                            + countDivBy2And3And5;

        // Numbers not divisible by 2, 3, or 5
        long count = N - totalDivisible;

        return count;
    }
}
