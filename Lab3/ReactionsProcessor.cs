namespace Lab3;

public static class ReactionsProcessor
{
    // Processes the input lines to extract reaction mappings and validates them
    public static Dictionary<string, string> ProcessReactions(List<string> lines, int numberOfReactions)
    {
        var reactions = new Dictionary<string, string>();
        Console.WriteLine("Processing reactions...");

        for (int i = 1; i <= numberOfReactions; i++)
        {
            string line = lines[i];
            if (string.IsNullOrEmpty(line))
            {
                Console.WriteLine($"Reaction {i} is empty.");
                throw new ArgumentException($"Reaction {i} is empty.", nameof(lines));
            }

            string[] reaction = line.Split(new string[] { " -> " }, StringSplitOptions.None);
            if (reaction.Length != 2 || !Utils.IsValidSubstanceName(reaction[0]) || !Utils.IsValidSubstanceName(reaction[1]))
            {
                Console.WriteLine($"Invalid reaction format for reaction {i}.");
                throw new FormatException($"Invalid reaction format at reaction {i}. Expected format: 'Substance1 -> Substance2'.");
            }

            if (reactions.ContainsKey(reaction[0]))
            {
                Console.WriteLine($"Duplicate reaction found for {reaction[0]}. Choosing the shortest path.");
            }
            reactions[reaction[0]] = reaction[1];
        }

        Console.WriteLine("Reactions processed successfully.");
        return reactions;
    }
}
