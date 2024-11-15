using System.Reflection;

namespace Lab3;

internal static class Program
{
    // Getting the path to the project directory
    private static readonly string ProjectDirectory = GetProjectDirectory();

    // Build paths to files relative to the project directory
    private static readonly string InputFilePath = Path.Combine(ProjectDirectory, "Files", "INPUT.txt");
    private static readonly string OutputFilePath = Path.Combine(ProjectDirectory, "Files", "OUTPUT.txt");

    // Gets the path to the project directory
    private static string GetProjectDirectory()
    {
        string exePath = Assembly.GetExecutingAssembly().Location;
        string exeDirectory = Path.GetDirectoryName(exePath)!;
        string projectDirectory = Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\.."));

        Console.WriteLine($"Project directory: {projectDirectory}");

        return projectDirectory;
    }

    private static void Main(string[] args)
    {
        var runner = new Lab3Runner();
        runner.Run(InputFilePath, OutputFilePath);
    }
}
