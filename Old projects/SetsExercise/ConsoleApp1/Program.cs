using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
          SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < count; i++)
            {
                var list = Console.ReadLine().Split().ToArray();
                for (int a = 0; a < list.Length; a++)
                {
                    string s = list[a];
                    set.Add(s);
                }
                

            }
            set.OrderBy(x=>x);
            Console.WriteLine(string.Join(" ",set));
        }
    }
}
