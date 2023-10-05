using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Cycle(line, n);
        }

        static void Cycle(string line, int n)
        {
            for (int i = 0; i<n; i++)
			{
                Console.Write(line);
			}
        }
    }
}
