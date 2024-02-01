using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => x.Length <= n)));
        }
    }
}
