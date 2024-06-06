using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split(' ').ToArray();
            List<int> list = new List<int>();
           int i = 0;
            foreach (var item in integers)
            {
               
                list.Add(int.Parse(integers[i]));
                i++;
            }
            list.Select(x => x % 2 == 0);
            string.Join(" ", integers);
        }
    }
}
