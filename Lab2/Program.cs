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
        try
        {
            // Initializing file and math services
            Console.WriteLine("Initializing services...");
            var fileService = new FileService(InputFilePath, OutputFilePath);
            var mathService = new MathService();

            // Reading input data from the file
            Console.WriteLine("Reading input data...");
            List<string[]> wordSets = fileService.ReadInputFile();
            var results = new List<int>();

            // Processing each word set
            foreach (var words in wordSets)
            {
                Console.WriteLine("Calculating maximum chain length...");
                int maxLength = MathService.CalculateMaxLength(words);
                results.Add(maxLength);
            }

            // Writing the results to the output file
            Console.WriteLine("Writing results to the output...");
            fileService.WriteOutputFile(results);

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            // Catching and showing any errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
