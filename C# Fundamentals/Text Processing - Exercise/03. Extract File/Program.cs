using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            string fileInfo = filePath.Substring(filePath.LastIndexOf('\\') + 1);

            string fileName = fileInfo.Substring(0, fileInfo.LastIndexOf('.'));
            string fileExtension = fileInfo.Substring(fileInfo.LastIndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
