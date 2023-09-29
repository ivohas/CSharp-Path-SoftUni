using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawInput = Console.ReadLine();

            string[] usernames = rawInput.Split(", ");

            List<string> validatedUsernames = new List<string>();

            bool isValid = false;

            foreach (string username in usernames)
            {
                if (isUsernameValid(username))
                {
                    validatedUsernames.Add(username);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validatedUsernames));

        }

        static bool isUsernameValid(string username)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {
                foreach (char symbol in username)
                {
                    if (char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_')
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
