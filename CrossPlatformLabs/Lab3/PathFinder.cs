namespace Lab3;

public static class PathFinder
{
    // Finds the shortest path using Dijkstra's algorithm
    public static int TransformSubstanceDijkstra(Dictionary<string, string> reactions, string start, string target)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<(string Substance, int Steps)>();
        queue.Enqueue((start, 0));

        Console.WriteLine($"Starting Dijkstra's algorithm from: {start}");

        while (queue.Count > 0)
        {
            var (Substance, Steps) = queue.Dequeue();
            var currentSubstance = Substance;
            var currentSteps = Steps;

            Console.WriteLine($"Current substance: {currentSubstance}, Steps taken: {currentSteps}");

            if (currentSubstance == target)
            {
                Console.WriteLine($"Target substance {target} found in {currentSteps} steps.");
                return currentSteps;
            }

            if (visited.Contains(currentSubstance))
            {
                Console.WriteLine($"Substance {currentSubstance} already visited, skipping.");
                continue;
            }

            visited.Add(currentSubstance);
            Console.WriteLine($"Visited substances: {string.Join(", ", visited)}");

            if (reactions.ContainsKey(currentSubstance))
            {
                var neighbor = reactions[currentSubstance];
                queue.Enqueue((neighbor, currentSteps + 1));
                Console.WriteLine($"Enqueued next substance: {neighbor} with steps: {currentSteps + 1}");
            }
        }

        Console.WriteLine("No satisfying path found.");
        return -1;
    }
}
