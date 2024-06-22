using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int Lenght = list.Count;

            for (int i = 0; i < Lenght / 2; i++)
            {
                list[i] += list[list.Count - i];
                list.RemoveAt(list.Count - i);
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
