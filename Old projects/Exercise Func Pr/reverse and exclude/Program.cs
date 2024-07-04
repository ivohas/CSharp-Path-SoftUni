using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_and_exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list= Console.ReadLine().Split().Select(int.Parse).ToList();
            list. Reverse();
            int n = int.Parse(Console.ReadLine());
            Func < List<int>, List<int>>  exlude = lists => lists.Where(x => x % n != 0).ToList();
            list= exlude(list);
            Console.WriteLine(String.Join(" ",list));
        }
    }
}
