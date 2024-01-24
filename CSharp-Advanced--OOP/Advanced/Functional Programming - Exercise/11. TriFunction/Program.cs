using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(names
                .First(n => 
                n.Select(symbol => (int) symbol).Sum() >= number));
        }
    }
}
