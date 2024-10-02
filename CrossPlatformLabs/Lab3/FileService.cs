namespace Lab3;

public static class FileService
{
    // Reads all sets of reactions and their input from the file
    public static List<List<string>> ReadMultipleSets(string path)
    {
        var sets = new List<List<string>>();
        Console.WriteLine("Reading multiple sets of data from file: " + path);

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                var set = new List<string>();

                // Read number of reactions and reactions themselves
                if (!int.TryParse(line, out int m))
                {
                    Console.WriteLine("Invalid number of reactions in a set.");
                    continue;
                }
                set.Add(line);

                for (int i = 0; i < m + 2; i++)
                {
                    line = reader.ReadLine()!;
                    if (line == null)
                    {
                        break;
                    }
                    set.Add(line);
                }

                if (set.Count == m + 3) // Ensure a complete set was read
                {
                    sets.Add(set);
                    Console.WriteLine($"Read a complete set with {m} reactions.");
                }
                else
                {
                    Console.WriteLine("Incomplete set found, skipping.");
                }
            }
        }

        return sets;
    }

    // Writes the results of all sets to a single output file
    public static void WriteAllResults(string filePath, List<int> results)
    {
        Console.WriteLine($"Writing results for {results.Count} sets to the file: {filePath}");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (int result in results)
            {
                writer.WriteLine(result);
                Console.WriteLine($"Successfully wrote result: {result}");
            }
        }
    }
}
