namespace Lab3.Tests;

public class UtilsTests
{
    [Theory]
    [InlineData("H2O", false)]
    [InlineData("Water", true)]
    [InlineData("CH3COOH", false)]
    [InlineData("A", true)]
    public void IsValidSubstanceName_TestCases_ReturnsExpectedResult(string name, bool expectedResult)
    {
        // Act
        var result = Utils.IsValidSubstanceName(name);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
