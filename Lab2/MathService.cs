namespace Lab2;

public static class MathService
{
    // Calculate the maximum length of the word chain
    public static int CalculateMaxLength(string[] words)
    {
        Console.WriteLine("Sorting words by length...");
        Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));

        int[] dp = new int[words.Length];
        int maxLength = 1;

        // Dynamic programming approach to find the longest chain
        for (int i = 0; i < words.Length; i++)
        {
            dp[i] = 1;
            Console.WriteLine($"Checking word {i + 1} for chain potential...");
            for (int j = 0; j < i; j++)
            {
                if (words[i].StartsWith(words[j]))
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            maxLength = Math.Max(maxLength, dp[i]);
        }

        return maxLength;
    }
}