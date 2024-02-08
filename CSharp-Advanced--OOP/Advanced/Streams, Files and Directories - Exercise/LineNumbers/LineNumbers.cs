namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                int countLetter = lines[i].Count(char.IsLetter);
                int countSymbol = lines[i].Count(char.IsPunctuation);
                Console.Write($"Line {i + 1}: ");
                Console.WriteLine($"{lines[i]} ({countLetter})({countSymbol})");
            }
        }
    }
}
