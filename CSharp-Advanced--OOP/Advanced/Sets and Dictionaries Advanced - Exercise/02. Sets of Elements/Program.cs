using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            (int n, int m) = (numbers[0], numbers[1]);

            var setN = new HashSet<int>();
            for (int i = 0; i < n; i++)
                setN.Add(int.Parse(Console.ReadLine()));

            var setM = new HashSet<int>();
            for (int i = 0; i < m; i++)
                setM.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine(string.Join(" ", setN.Where(x => setM.Contains(x))));
        }
    }
}
