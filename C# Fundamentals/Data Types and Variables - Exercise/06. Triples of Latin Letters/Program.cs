using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char c1, c2, c3;

            for (char b = (char)97; b < (char)97 + n; b++)
            {
                c1 = b;
                for (char c = (char)97; c < (char)97 + n; c++)
                {
                    c2 = c;
                    for (char d = (char)97; d < (char)97 + n; d++)
                    {
                        c3 = d;
                        Console.WriteLine(c1 + "" + c2 + "" + c3);
                    }
                }
            }
        }
    }
}
