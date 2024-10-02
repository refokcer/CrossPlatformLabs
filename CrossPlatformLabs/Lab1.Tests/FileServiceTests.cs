namespace Lab1.Tests;

public class FileServiceTests
{
    [Fact]
    public void ReadInputNumbers_ReturnsNull_ForInvalidInput()
    {
        // Arrange
        string tempInputFile = Path.GetTempFileName();
        string tempOutputFile = Path.GetTempFileName();
        File.WriteAllLines(tempInputFile, new[] { "1", "invalid", "3" });

        FileService fileService = new FileService(tempInputFile, tempOutputFile);

        // Act
        List<long> result = fileService.ReadInputNumbers()!;

        // Assert
        Assert.Null(result); // Result should be null due to invalid input

        // Check that an error message was written to the output file
        string outputContent = File.ReadAllText(tempOutputFile);
        Assert.Contains("Error: Line 2 in INPUT.txt is not a valid integer.", outputContent);

        // Cleanup
        File.Delete(tempInputFile);
        File.Delete(tempOutputFile);
    }

    [Fact]
    public void WriteOutputResults_HandlesException_ForInvalidFilePath()
    {
        // Arrange
        string invalidFilePath = ""; // Invalid file path to simulate an error
        FileService fileService = new FileService(invalidFilePath, invalidFilePath);

        IEnumerable<string> results = new List<string> { "Result 1", "Result 2", "Result 3" };

        // Capture console output
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            // Act
            fileService.WriteOutputResults(results);

            // Assert
            Assert.Contains("Error writing output file", consoleOutput.ToString());
        }
    }
}
