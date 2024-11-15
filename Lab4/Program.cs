using CrossPlatformLabs.LabRunner;

namespace Lab4;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        switch (args[0].ToLower())
        {
            case "version":
                ShowVersion();
                break;
            case "run":
                RunLab(args);
                break;
            case "set-path":
                SetPath(args);
                break;
            default:
                Console.WriteLine("Unknown command.");
                ShowHelp();
                break;
        }
    }

    static void ShowVersion()
    {
        Console.WriteLine("Author: Artem Karandashov");
        Console.WriteLine("Version: 1.0.1");
    }

    static void RunLab(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please specify a lab to run (lab1, lab2, lab3).");
            return;
        }

        string labName = args[1];
        string inputFile = null!;
        string outputFile = null!;

        // Разбор дополнительных параметров
        for (int i = 2; i < args.Length; i++)
        {
            if (args[i] == "-I" || args[i] == "--input")
            {
                if (i + 1 < args.Length)
                {
                    inputFile = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine("Please specify an input file.");
                    return;
                }
            }
            else if (args[i] == "-o" || args[i] == "--output")
            {
                if (i + 1 < args.Length)
                {
                    outputFile = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine("Please specify an output file.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Unknown parameter: {args[i]}");
                return;
            }
        }

        // Определение путей к входному и выходному файлам
        inputFile = GetInputFilePath(inputFile);
        outputFile = GetOutputFilePath(outputFile);

        if (inputFile == null)
        {
            Console.WriteLine("Input file not specified and could not be found.");
            return;
        }

        var labRunner = new LabRunner();
        try
        {
            labRunner.RunLab(labName, inputFile, outputFile);
            Console.WriteLine($"{labName} completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running {labName}: {ex.Message}");
        }
    }

    static void SetPath(string[] args)
    {
        string path = null!;

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] == "-p" || args[i] == "--path")
            {
                if (i + 1 < args.Length)
                {
                    path = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine("Please specify a path.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Unknown parameter: {args[i]}");
                return;
            }
        }

        if (path == null)
        {
            Console.WriteLine("Please specify a path using -p or --path.");
            return;
        }

        Environment.SetEnvironmentVariable("LAB_PATH", path);
        Console.WriteLine($"LAB_PATH set to {path}");
    }

    static string GetInputFilePath(string inputFile)
    {
        // Приоритетность пути
        if (inputFile != null && System.IO.File.Exists(inputFile))
        {
            return inputFile;
        }

        string labPath = Environment.GetEnvironmentVariable("LAB_PATH")!;
        if (!string.IsNullOrEmpty(labPath))
        {
            string filePath = System.IO.Path.Combine(labPath, "input.txt");
            if (System.IO.File.Exists(filePath))
            {
                return filePath;
            }
        }

        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string homeInputFile = System.IO.Path.Combine(homePath, "input.txt");
        if (System.IO.File.Exists(homeInputFile))
        {
            return homeInputFile;
        }

        return null!;
    }

    static string GetOutputFilePath(string outputFile)
    {
        if (outputFile != null)
        {
            return outputFile;
        }

        string labPath = Environment.GetEnvironmentVariable("LAB_PATH")!;
        if (!string.IsNullOrEmpty(labPath))
        {
            return System.IO.Path.Combine(labPath, "output.txt");
        }

        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return System.IO.Path.Combine(homePath, "output.txt");
    }

    static void ShowHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  version");
        Console.WriteLine("  run <lab1|lab2|lab3> [-I|--input <inputFile>] [-o|--output <outputFile>]");
        Console.WriteLine("  set-path -p|--path <path>");
    }
}
