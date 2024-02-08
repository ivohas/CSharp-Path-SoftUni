
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    int lineNumber = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber % 2 == 1)
                            writer.WriteLine(line);
                        lineNumber++;
                    }
                }
            }
        }
    }
}
