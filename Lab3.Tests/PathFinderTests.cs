namespace Lab3.Tests;

public class PathFinderTests
{
    [Fact]
    public void TransformSubstanceDijkstra_ValidInput_ReturnsCorrectSteps()
    {
        // Arrange
        var reactions = new Dictionary<string, string>
    {
        { "A", "B" },
        { "B", "F" },
        { "F", "E" },
        { "D", "E" }
    };

        // Act
        var result = PathFinder.TransformSubstanceDijkstra(reactions, "A", "E");

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void TransformSubstanceDijkstra_NoPath_ReturnsMinusOne()
    {
        // Arrange
        var reactions = new Dictionary<string, string>
    {
        { "A", "B" },
        { "B", "F" },
        { "F", "E" }
    };

        // Act
        var result = PathFinder.TransformSubstanceDijkstra(reactions, "D", "E");

        // Assert
        Assert.Equal(-1, result);
    }
}
