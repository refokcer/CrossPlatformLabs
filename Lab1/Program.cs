using System.Reflection;

namespace Lab1;

internal static class Program
{
    // Getting the path to the project directory
    private static readonly string ProjectDirectory = GetProjectDirectory();

    // Build paths to files relative to the project directory
    private static readonly string InputFilePath = Path.Combine(ProjectDirectory, "Files", "INPUT.txt");
    private static readonly string OutputFilePath = Path.Combine(ProjectDirectory, "Files", "OUTPUT.txt");

    private static string GetProjectDirectory()
    {
        //  Get the path to the executable file
        string exePath = Assembly.GetExecutingAssembly().Location;
        string exeDirectory = Path.GetDirectoryName(exePath)!;

        // Climb three levels up to get to the project catalog
        string projectDirectory = Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\.."));

        return projectDirectory;
    }

    static void Main(string[] args)
    {
        var runner = new Lab1Runner();
        runner.Run(InputFilePath, OutputFilePath);
    }
}
