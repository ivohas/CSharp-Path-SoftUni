using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pridicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           List<string> names = Console.ReadLine().Split().ToList();
            Func<List<string>, List<string>> name = lists => lists.Where(x => x.Length <= n).ToList();
            names = name(names);
            Console.WriteLine(String.Join("\r\n", names));
        }
    }
}
