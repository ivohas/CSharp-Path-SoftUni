using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestsList = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = cmdArgs[0];

                if (cmdArgs.Length == 3)
                {
                    if (guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }

                    guestsList.Add(name);
                }
                else if (cmdArgs.Length == 4)
                {
                    if (!guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }
                    guestsList.Remove(name);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, guestsList));
        }
    }
}
