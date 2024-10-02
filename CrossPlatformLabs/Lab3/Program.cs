using System.Reflection;

namespace Lab3;

internal class Program
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
        string exeDirectory = Path.GetDirectoryName(exePath);
        string projectDirectory = Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\.."));
        Console.WriteLine($"Project directory: {projectDirectory}");
        return projectDirectory;
    }

    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Program started.");

            // Read all lines from the input file
            var lines = FileService.ReadLines(InputFilePath);

            // Get the number of reactions from the first line
            if (!int.TryParse(lines[0], out int numberOfReactions) || numberOfReactions < 0 || numberOfReactions > 1000)
            {
                Console.WriteLine("Invalid number of reactions.");
                return;
            }

            Console.WriteLine($"Number of reactions: {numberOfReactions}");

            // Process the reactions using the ReactionsProcessor class
            var reactions = ReactionsProcessor.ProcessReactions(lines, numberOfReactions);

            // Read the starting and target substances from the input
            string startSubstance = lines[numberOfReactions + 1];
            string desiredSubstance = lines[numberOfReactions + 2];

            // Validate the substance names
            if (!Utils.IsValidSubstanceName(startSubstance) || !Utils.IsValidSubstanceName(desiredSubstance))
            {
                Console.WriteLine("Invalid substance name.");
                return;
            }

            // Use the PathFinder class to find the shortest path
            int result = PathFinder.TransformSubstanceDijkstra(reactions, startSubstance, desiredSubstance);

            // Write the result to the output file
            FileService.WriteLine(OutputFilePath, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

}
