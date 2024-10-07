namespace Lab2;

public class FileService
{
    private readonly string _inputFilePath;
    private readonly string _outputFilePath;

    public FileService(string inputFilePath, string outputFilePath)
    {
        _inputFilePath = inputFilePath;
        _outputFilePath = outputFilePath;
    }

    // Reading input file and extracting word sets
    public List<string[]> ReadInputFile()
    {
        var wordSets = new List<string[]>();

        using (StreamReader reader = new StreamReader(_inputFilePath))
        {
            // Loop until we reach the end of the file
            while (!reader.EndOfStream)
            {
                Console.WriteLine("Reading number of words in the current set...");

                if (!int.TryParse(reader.ReadLine()?.Trim(), out int M) || M < 1 || M > 255)
                {
                    var error = "Invalid value for M in INPUT.txt";
                    Utils.WriteError(_outputFilePath, error);
                    throw new ArgumentException(error);
                }

                string[] words = new string[M];
                // Reading words for the current set
                for (int i = 0; i < M; i++)
                {
                    Console.WriteLine($"Reading word {i + 1} from the input...");
                    string? word = reader.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(word) || word.Length > 255 || !word.All(char.IsLower) || words.Contains(word))
                    {
                        var error = $"Invalid word at line {i + 2} in INPUT.txt";
                        Utils.WriteError(_outputFilePath, error);
                        throw new ArgumentException(error);
                    }
                    words[i] = word;
                }

                wordSets.Add(words);
            }
        }

        return wordSets;
    }

    // Writing results to the output file
    public void WriteOutputFile(List<int> results)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_outputFilePath))
            {
                Console.WriteLine("Writing results to the output file...");
                foreach (var result in results)
                {
                    writer.WriteLine(result);
                }
            }
        }
        catch (Exception ex)
        {
            // Output error to console if writing fails
            Console.WriteLine("Error writing output file: " + ex.Message);
        }
        
    }
}
