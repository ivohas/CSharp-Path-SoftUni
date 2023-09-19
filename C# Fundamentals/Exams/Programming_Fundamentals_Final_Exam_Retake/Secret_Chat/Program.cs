using System;
using System.Linq;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main()
            {
                string message = Console.ReadLine();

                string input;
            BREAK:
                while ((input = Console.ReadLine()) != "Reveal")
                {
                    string[] inputArgs = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                    string command = inputArgs[0];

                    if (command == "InsertSpace")
                    {
                        int index = int.Parse(inputArgs[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                    }
                    else if (command == "Reverse")
                    {
                        string subString = inputArgs[1];
                        if (message.Contains(subString))
                        {
                            int substringIndex = message.IndexOf(subString);
                            message = message.Remove(substringIndex, subString.Length);
                            message = message + String.Join("", subString.Reverse());
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                            goto BREAK;
                        }
                    }
                    else if (command == "ChangeAll")
                    {
                        string oldSubstring = inputArgs[1];
                        string replacement = inputArgs[2];

                        int currIndex = 0;
                        if (message.Contains(oldSubstring))
                        {
                            int firstIndex = message.IndexOf(oldSubstring);
                            while (message.LastIndexOf(oldSubstring) >= firstIndex)
                            {
                                currIndex = message.LastIndexOf(oldSubstring);
                                for (int i = 0; i < oldSubstring.Length; i++)
                                {
                                    message = message.Remove(currIndex, 1);

                                }
                                message = message.Insert(currIndex, replacement);
                            }

                            Console.WriteLine(message);
                        }

                    }
                }
                Console.WriteLine($"You have a new text message: {message}");
            }
        }
    }
}
