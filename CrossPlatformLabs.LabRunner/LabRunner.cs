using Lab1;
using Lab2;
using Lab3;

namespace CrossPlatformLabs.LabRunner
{
    public class LabRunner
    {
        public void RunLab(string labName, string inputFilePath, string outputFilePath)
        {
            switch (labName.ToLower())
            {
                case "lab1":
                    var lab1 = new Lab1Runner();
                    lab1.Run(inputFilePath, outputFilePath);
                    break;
                case "lab2":
                    var lab2 = new Lab2Runner();
                    lab2.Run(inputFilePath, outputFilePath);
                    break;
                case "lab3":
                    var lab3 = new Lab3Runner();
                    lab3.Run(inputFilePath, outputFilePath);
                    break;
                default:
                    throw new ArgumentException("Invalid lab name");
            }
        }
    }
}