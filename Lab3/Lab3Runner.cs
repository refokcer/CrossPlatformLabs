namespace Lab3;

public class Lab3Runner
{
    public void Run(string InputFilePath, string OutputFilePath)
    {
        try
        {
            Console.WriteLine("Program started.");

            // Считываем входные данные
            var multipleSets = FileService.ReadMultipleSets(InputFilePath);

            // Передаём данные на обработку в отдельный метод
            var results = ProcessInput(multipleSets);

            // Записываем результаты в выходной файл
            FileService.WriteAllResults(OutputFilePath, results);

            Console.WriteLine("Program finished.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public List<int> ProcessInput(List<List<string>> multipleSets)
    {
        var results = new List<int>();

        foreach (var set in multipleSets)
        {
            // Проверяем корректность количества реакций
            if (!int.TryParse(set[0], out int numberOfReactions) || numberOfReactions < 0 || numberOfReactions > 1000)
            {
                Console.WriteLine("Invalid number of reactions.");
                results.Add(-1);
                continue;
            }

            // Обрабатываем реакции
            var reactions = ReactionsProcessor.ProcessReactions(set, numberOfReactions);

            // Чтение начального и целевого вещества
            string startSubstance = set[numberOfReactions + 1];
            string desiredSubstance = set[numberOfReactions + 2];

            // Валидация названий веществ
            if (!Utils.IsValidSubstanceName(startSubstance) || !Utils.IsValidSubstanceName(desiredSubstance))
            {
                Console.WriteLine("Invalid substance name.");
                results.Add(-1);
                continue;
            }

            // Находим кратчайший путь
            int result = PathFinder.TransformSubstanceDijkstra(reactions, startSubstance, desiredSubstance);
            results.Add(result);
        }

        return results;
    }

    public List<List<string>> ConvertToNestedStringList(List<string> input)
    {
        var result = new List<List<string>>();
        int i = 0;

        while (i < input.Count)
        {
            // Попробуем извлечь количество реакций из первой строки набора
            if (int.TryParse(input[i], out int numberOfReactions) && numberOfReactions >= 0)
            {
                // Проверяем, достаточно ли строк для текущего набора
                if (i + numberOfReactions + 2 >= input.Count)
                {
                    Console.WriteLine($"Warning: Not enough data for the set starting at line {i + 1}. Skipping.");
                    break;
                }

                // Извлекаем текущий набор данных
                var set = input.Skip(i).Take(numberOfReactions + 3).ToList();
                result.Add(set);

                // Переходим к следующему набору
                i += numberOfReactions + 3;
            }
            else
            {
                Console.WriteLine($"Warning: Invalid reaction count at line {i + 1}: '{input[i]}'. Skipping.");
                i++;
            }
        }

        return result;
    }
}
