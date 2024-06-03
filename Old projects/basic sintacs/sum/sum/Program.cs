using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                int b = a * i;
                Console.WriteLine($"{a} X {i} = {b}");
            }
        }
    }
}
