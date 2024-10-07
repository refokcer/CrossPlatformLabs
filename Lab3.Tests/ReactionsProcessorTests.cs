namespace Lab3.Tests;

public class ReactionsProcessorTests
{
    [Fact]
    public void ProcessReactions_ValidInput_ReturnsCorrectDictionary()
    {
        // Arrange
        var lines = new List<string>
    {
        "4",       // Number of reactions
        "A -> B",
        "B -> F",
        "F -> E",
        "D -> E",
        "A",       // Start substance
        "E"        // Target substance
    };

        // Act
        var result = ReactionsProcessor.ProcessReactions(lines, 4);

        // Assert
        Assert.Equal("B", result["A"]);
        Assert.Equal("F", result["B"]);
        Assert.Equal("E", result["F"]);
        Assert.Equal("E", result["D"]);
    }

    [Fact]
    public void ProcessReactions_InvalidReactionFormat_ThrowsFormatException()
    {
        // Arrange
        var lines = new List<string>
        {
            "2",
            "A ->",     
            "B -> C",
            "A",
            "C"
        };

        // Act & Assert
        Assert.Throws<FormatException>(() => ReactionsProcessor.ProcessReactions(lines, 2));
    }

}
