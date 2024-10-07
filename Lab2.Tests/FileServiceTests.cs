namespace Lab2.Tests;

public class FileServiceTests
{
    private const string InputFilePath = "TestFiles/INPUT.txt";
    private const string OutputFilePath = "TestFiles/OUTPUT.txt";

    public FileServiceTests()
    {
        // Ensure test files directory exists
        if (!Directory.Exists("TestFiles"))
            Directory.CreateDirectory("TestFiles");
    }

    [Fact]
    public void ReadInputFile_ShouldReturnCorrectWordSets()
    {
        // Arrange
        var inputContent = "3\na\nab\nabc\n5\na\nab\nbc\nbcd\nadd\n";
        File.WriteAllText(InputFilePath, inputContent);
        var fileService = new FileService(InputFilePath, OutputFilePath);

        // Act
        var wordSets = fileService.ReadInputFile();

        // Assert
        Assert.Equal(2, wordSets.Count);
        Assert.Equal(new[] { "a", "ab", "abc" }, wordSets[0]);
        Assert.Equal(new[] { "a", "ab", "bc", "bcd", "add" }, wordSets[1]);
    }

    [Fact]
    public void ReadInputFile_ShouldThrowArgumentOutOfRangeException_OnInvalidMValue()
    {
        // Arrange
        File.WriteAllText(InputFilePath, "300\na\nab\nabc\n");
        var fileService = new FileService(InputFilePath, OutputFilePath);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => fileService.ReadInputFile());
    }

    [Fact]
    public void WriteOutputFile_ShouldWriteResultsCorrectly()
    {
        // Arrange
        var fileService = new FileService(InputFilePath, OutputFilePath);
        var results = new List<int> { 3, 4 };

        // Act
        fileService.WriteOutputFile(results);

        // Assert
        var writtenContent = File.ReadAllLines(OutputFilePath);
        Assert.Equal(new[] { "3", "4" }, writtenContent);
    }
}
