namespace Lab3.Tests;

public class FileServiceTests
{
    [Fact]
    public void ReadMultipleSets_ValidFile_ReturnsCorrectSets()
    {
        // Arrange
        string tempFilePath = Path.GetTempFileName();
        File.WriteAllLines(tempFilePath, new[]
        {
        "2",
        "A -> B",
        "B -> C",
        "A",
        "C",
        "1",
        "X -> Y",
        "X",
        "Y"
    });

        // Act
        var result = FileService.ReadMultipleSets(tempFilePath);

        // Assert
        Assert.Equal(2, result.Count); // Two sets
        Assert.Equal("A -> B", result[0][1]); // First reaction in first set
        Assert.Equal("X -> Y", result[1][1]); // First reaction in second set

        // Cleanup
        File.Delete(tempFilePath);
    }

    [Fact]
    public void WriteAllResults_ValidResults_WritesToFile()
    {
        // Arrange
        string tempFilePath = Path.GetTempFileName();
        var results = new List<int> { 2, -1, 3 };

        // Act
        FileService.WriteAllResults(tempFilePath, results);

        // Assert
        var fileContent = File.ReadAllLines(tempFilePath);
        Assert.Equal("2", fileContent[0]);
        Assert.Equal("-1", fileContent[1]);
        Assert.Equal("3", fileContent[2]);

        // Cleanup
        File.Delete(tempFilePath);
    }
}
