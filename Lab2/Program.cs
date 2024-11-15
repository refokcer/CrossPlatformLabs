using System.Reflection;

namespace Lab2;

internal static class Program
{
    // Defining project directory
    private static readonly string ProjectDirectory = GetProjectDirectory();
    // Input and output file paths
    private static readonly string InputFilePath = Path.Combine(ProjectDirectory, "Files", "INPUT.txt");
    private static readonly string OutputFilePath = Path.Combine(ProjectDirectory, "Files", "OUTPUT.txt");

    // Getting the project directory
    private static string GetProjectDirectory()
    {
        Console.WriteLine("Getting the project directory...");
        string exePath = Assembly.GetExecutingAssembly().Location;
        string exeDirectory = Path.GetDirectoryName(exePath)!;

        return Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\.."));
    }

    static void Main()
    {
        var runner = new Lab2Runner();
        runner.Run(InputFilePath, OutputFilePath);
    }
}
