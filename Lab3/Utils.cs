using System.Text.RegularExpressions;

namespace Lab3;

public static class Utils
{
    public static bool IsValidSubstanceName(string name)
    {
        Console.WriteLine($"Checking if {name} is a valid substance name.");
        try
        {
            bool isValid = !string.IsNullOrEmpty(name) &&
                           name.Length <= 20 &&
                           Regex.IsMatch(name, @"^[a-zA-Z]+$", RegexOptions.None, TimeSpan.FromMilliseconds(500));
            Console.WriteLine($"Validation result for {name}: {isValid}");
            return isValid;
        }
        catch (RegexMatchTimeoutException)
        {
            Console.WriteLine($"Regex match timeout for {name}");
            return false;
        }
    }
}