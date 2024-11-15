namespace Lab3;

public class Lab3Runner
{
    public void Run(string InputFilePath, string OutputFilePath)
    {
        try
        {
            Console.WriteLine("Program started.");

            // Read multiple sets from the input file
            var multipleSets = FileService.ReadMultipleSets(InputFilePath);
            var results = new List<int>();

            // Process each set of reactions and find the shortest path
            foreach (var set in multipleSets)
            {
                // Get the number of reactions from the first line
                if (!int.TryParse(set[0], out int numberOfReactions) || numberOfReactions < 0 || numberOfReactions > 1000)
                {
                    Console.WriteLine("Invalid number of reactions.");
                    results.Add(-1);
                    continue;
                }

                // Process the reactions using the ReactionsProcessor class
                var reactions = ReactionsProcessor.ProcessReactions(set, numberOfReactions);

                // Read the starting and target substances from the input
                string startSubstance = set[numberOfReactions + 1];
                string desiredSubstance = set[numberOfReactions + 2];

                // Validate the substance names
                if (!Utils.IsValidSubstanceName(startSubstance) || !Utils.IsValidSubstanceName(desiredSubstance))
                {
                    Console.WriteLine("Invalid substance name.");
                    results.Add(-1);
                    continue;
                }

                // Use the PathFinder class to find the shortest path
                int result = PathFinder.TransformSubstanceDijkstra(reactions, startSubstance, desiredSubstance);
                results.Add(result);
            }

            // Write results for all sets to a single output file
            FileService.WriteAllResults(OutputFilePath, results);

            Console.WriteLine("Program finished.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}