using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lists = new List<string>();
           int i = 0;
            for (i=0; i < n; i++)
            { string a=Console.ReadLine ();
                lists.Add(a);
            }
            lists.Sort();
            
            for(i = 0; i < n; i++)
            {
                
                Console.WriteLine($"{i + 1}.{lists[i]}");
                
            }
        }
    }
}
