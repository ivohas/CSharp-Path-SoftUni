using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOffElemants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            HashSet<int> vs = new HashSet<int>();
            HashSet<int> vs1 = new HashSet<int>();
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int n = list[0];
            int m = list[1];
            for (int i = 0; i < n; i++)
            {
                int a =int.Parse(Console.ReadLine());
                set.Add(a);
            }
            for (int i = 0; i < m; i++)
            {
                int a = int.Parse(Console.ReadLine());
                vs.Add(a);
            }
            set.IntersectWith(vs);
            Console.WriteLine( string.Join(" ", set));
        }
    }
}
