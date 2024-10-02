namespace Lab3;

public static class FileService
{
    public static List<string> ReadLines(string path)
    {
        Console.WriteLine("Reading lines from file: " + path);
        var lines = new List<string>();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
                Console.WriteLine($"Read line: {line}");
            }
        }

        return lines;
    }

    public static void WriteLine(string path, int result)
    {
        Console.WriteLine($"Writing result: {result} to file: {path}");
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine(result);
            Console.WriteLine($"Successfully wrote the result to the file.");
        }
    }
}
