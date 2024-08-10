using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(a))
                    dict.Add(a, 0);
                dict[a]++;
            }
            Console.WriteLine(dict.First(x=>x.Value%2==0).Key);
        }
    }
}
