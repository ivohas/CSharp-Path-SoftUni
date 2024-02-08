namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal folderSize = 0;
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (var f in dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                fols
            }
        }
    }
}
