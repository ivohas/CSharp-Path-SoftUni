using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
