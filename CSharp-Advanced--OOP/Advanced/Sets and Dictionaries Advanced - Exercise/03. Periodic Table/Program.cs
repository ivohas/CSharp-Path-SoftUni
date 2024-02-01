using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var chemCompounds = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemCompound = Console.ReadLine().Split();
                foreach (string cc in chemCompound)
                {
                    chemCompounds.Add(cc);
                }
            }

            Console.WriteLine(string.Join(" ", chemCompounds.OrderBy(x => x)));
        }
    }
}
