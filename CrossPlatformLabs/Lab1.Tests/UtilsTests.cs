namespace Lab1.Tests;

public class UtilsTests
{
    [Fact]
    public void WriteError_WritesErrorMessageToFileAndConsole()
    {
        // Arrange
        string expectedMessage = "This is an error message.";
        string tempFilePath = Path.GetTempFileName(); // Create a temporary file

        // Capture console output
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            // Act
            Utils.WriteError(tempFilePath, expectedMessage);

            // Assert
            // Verify the message was written to the file
            string fileContent = File.ReadAllText(tempFilePath);
            Assert.Contains(expectedMessage, fileContent);

            // Verify the message was printed to the console
            Assert.Contains(expectedMessage, consoleOutput.ToString());
        }

        // Clean up: delete the temporary file after the test
        File.Delete(tempFilePath);
    }

    [Fact]
    public void WriteError_HandlesExceptionAndOutputsErrorToConsole()
    {
        // Arrange
        string expectedMessage = "This is an error message.";
        string invalidFilePath = ""; // Invalid file path to trigger an exception

        // Capture console output
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            // Act
            Utils.WriteError(invalidFilePath, expectedMessage);

            // Assert
            // Verify the error message was printed to the console
            Assert.Contains("Error writing output file", consoleOutput.ToString());
        }
    }
}
