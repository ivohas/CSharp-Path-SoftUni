using System;
using System.Linq;

namespace Problem_3___World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stopStr = Console.ReadLine();

            string cmdInfo;
            while ((cmdInfo = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = cmdInfo
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                if (cmdType == "Add Stop")
                {
                    int insertIndex = int.Parse(cmdArgs[1]);
                    string insertString = cmdArgs[2];

                    stopStr = InsertStringAtIndex(stopStr, insertIndex, insertString);
                    Console.WriteLine(stopStr);
                }
                else if (cmdType == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    stopStr = RemoveStringInRange(stopStr, startIndex, endIndex);
                    Console.WriteLine(stopStr);
                }
                else if (cmdType == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    stopStr = ReplaceAllOccurances(stopStr, oldString, newString);
                    Console.WriteLine(stopStr);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stopStr}");
        }

        static string InsertStringAtIndex(string originalString, int insertIndex, string insertString)
        {
            if (!IsIndexValid(originalString, insertIndex))
            {
                return originalString;
            }

            string modifiedString = originalString.Insert(insertIndex, insertString);

            return modifiedString;
        }

        static string RemoveStringInRange(string originalString, int startIndex, int endIndex)
        {
            if (!IsIndexValid(originalString, startIndex))
            {
                return originalString;
            }

            if (!IsIndexValid(originalString, endIndex))
            {
                return originalString;
            }

            string modifiedString = originalString.Remove(startIndex, endIndex - startIndex + 1);
            return modifiedString;
        }

        static string ReplaceAllOccurances(string originalString, string oldString, string newString)
        {
            string modifiedString = originalString.Replace(oldString, newString);

            return modifiedString;
        }
        static bool IsIndexValid(string str, int index)
        {
            return index >= 0 && index < str.Length;
        }
    }
}
