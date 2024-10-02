using System;
using System.Text.RegularExpressions;

namespace Lab3;

public static class Utils
{
    public static bool IsValidSubstanceName(string name)
    {
        Console.WriteLine($"Checking if {name} is a valid substance name.");
        bool isValid = !string.IsNullOrEmpty(name) && name.Length <= 20 && Regex.IsMatch(name, @"^[a-zA-Z]+$");
        Console.WriteLine($"Validation result for {name}: {isValid}");
        return isValid;
    }
}
