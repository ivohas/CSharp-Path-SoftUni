using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 1;int b = a;
            while (n >= b)
            {Console.WriteLine(b);
                b = b * 2 + 1;  
            }
           


        }
    }
}
