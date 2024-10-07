namespace Lab2.Tests;

public class MathServiceTests
{
    [Fact]
    public void CalculateMaxLength_ShouldReturnCorrectLength_ForSingleChain()
    {
        // Arrange
        var words = new[] { "a", "ab", "abc", "abcd" };

        // Act
        var result = MathService.CalculateMaxLength(words);

        // Assert
        Assert.Equal(4, result); // All words form a chain
    }

    [Fact]
    public void CalculateMaxLength_ShouldReturnCorrectLength_ForMultipleChains()
    {
        // Arrange
        var words = new[] { "a", "ab", "bc", "bcd", "cde" };

        // Act
        var result = MathService.CalculateMaxLength(words);

        // Assert
        Assert.Equal(2, result); // Two separate chains: ["a", "ab"], ["bc", "bcd"]
    }

    [Fact]
    public void CalculateMaxLength_ShouldHandleSingleWord()
    {
        // Arrange
        var words = new[] { "a" };

        // Act
        var result = MathService.CalculateMaxLength(words);

        // Assert
        Assert.Equal(1, result); // Single word has a length of 1
    }

    [Fact]
    public void CalculateMaxLength_ShouldReturn1_ForNonMatchingWords()
    {
        // Arrange
        var words = new[] { "cat", "dog", "fish" };

        // Act
        var result = MathService.CalculateMaxLength(words);

        // Assert
        Assert.Equal(1, result); // No words can form a chain
    }
}
