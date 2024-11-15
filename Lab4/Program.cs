using CrossPlatformLabs.LabRunner;
using McMaster.Extensions.CommandLineUtils;

namespace lab4;

[Command(Name = "Lab4", Description = "Console app for labs")]
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
class Program
{
    static int Main(string[] args)
    {
        // Проверяем аргументы перед вызовом CommandLineApplication.Execute
        if (args.Length == 0 || !IsValidCommand(args[0]))
        {
            OnUnknownCommand();
            return 1; // Завершаем с ненулевым кодом ошибки
        }

        return CommandLineApplication.Execute<Program>(args);
    }

    private void OnExecute()
    {
        Console.WriteLine("Specify a command");
    }

    private static void OnUnknownCommand()
    {
        Console.WriteLine("Unknown command. Use one of the following:");
        Console.WriteLine(" - version: Displays app version and author");
        Console.WriteLine(" - run: Run a specific lab");
        Console.WriteLine(" - set-path: Set input/output path");
    }

    private static bool IsValidCommand(string command)
    {
        // Список допустимых команд
        var validCommands = new[] { "version", "run", "set-path", "--help", "-h" };
        return validCommands.Contains(command.ToLower());
    }
}

[Command(Name = "version", Description = "Displays app version and author")]
class VersionCommand
{
    private void OnExecute()
    {
        Console.WriteLine("Author: Artem Karandashov");
        Console.WriteLine("Version: 1.0.1");
    }
}

[Command(Name = "run", Description = "Run a specific lab")]
class RunCommand
{
    [Argument(0, "lab", "Specify lab to run (lab1)")]
    public string? Lab { get; set; }

    [Option("-I|--input", "Input file", CommandOptionType.SingleValue)]
    public string? InputFile { get; set; }

    [Option("-o|--output", "Output file", CommandOptionType.SingleValue)]
    public string? OutputFile { get; set; }


    private void OnExecute()
    {
        string? labPath = Directory.GetCurrentDirectory();
        if (labPath == null)
        {
            Console.WriteLine($"Unknown lab '{Lab}'. Available labs: lab1.");
            return;
        }

        // Перевірка пріоритетності шляху
        Console.WriteLine(Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User));
        string inputFilePath = InputFile ?? Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User) ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "INPUT.txt");
        string outputFilePath = OutputFile ?? Path.Combine(labPath, "OUTPUT.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Input file '{inputFilePath}' not found.");
            return;
        }

        var runner = new LabRunner();

        switch (Lab.ToLower())
        {
            case "lab1":
                runner.RunLab("lab1", inputFilePath, outputFilePath);
                break;
            case "lab2":
                runner.RunLab("lab2", inputFilePath, outputFilePath);
                break;
            case "lab3":
                runner.RunLab("lab3", inputFilePath, outputFilePath);
                break;
            default:
                Console.WriteLine("Unknown lab specified.");
                break;
        }

        Console.WriteLine($"Lab {Lab} processed. Output saved to {outputFilePath}");
    }
}

[Command(Name = "set-path", Description = "Set input/output path")]
class SetPathCommand
{
    [Option("-p|--path", "Path to input/output files", CommandOptionType.SingleValue)]
    public required string Path { get; set; }

    private void OnExecute()
    {
        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine($"Path set to: {Path}");
    }
}