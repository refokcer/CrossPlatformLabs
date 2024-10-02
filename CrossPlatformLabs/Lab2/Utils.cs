using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2;

public static class Utils
{
    public static void WriteError(string OutputFilePath, string errorMessage)
    {
        try
        {
            // Open the file in append mode by passing true as the second argument
            using (StreamWriter writer = new StreamWriter(OutputFilePath))
            {
                writer.WriteLine(errorMessage);
                Console.WriteLine(errorMessage);
            }
        }
        catch (Exception ex)
        {
            // Output error to console if writing fails
            Console.WriteLine("Error writing output file: " + ex.Message);
        }
    }
}
