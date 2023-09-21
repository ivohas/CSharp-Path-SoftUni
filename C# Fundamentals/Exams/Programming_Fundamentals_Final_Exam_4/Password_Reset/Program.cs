using System;
using System.Text;

namespace Problem_8___Password_Reset
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "TakeOdd")
                {
                    input = TakeOdd(input);
                }
                else if (cmdType == "Cut")
                {
                    input = Cut(input, cmdArgs);

                }
                else if (cmdType == "Substitute")
                {
                    string modifiedString = Substitute(input, cmdArgs);
                    if (modifiedString != null && modifiedString != "null")
                    {
                        input = Substitute(input, cmdArgs);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                }
                Console.WriteLine(input);
            }
            Console.WriteLine($"Your password is: {input}");
        }

        static string TakeOdd(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }

        static string Cut(string input, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            int lenght = int.Parse(cmdArgs[2]);

            input = input.Remove(index, lenght);

            return input;
        }

        static string Substitute(string input, string[] cmdArgs)
        {
            string substring = cmdArgs[1];
            string substitute = cmdArgs[2];

            if (input.Contains(substring))
            {
                input = input.Replace(substring, substitute);
            }
            else
            {
                return "null";
            }

            return input;
        }
    }
}
