using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _23._3._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
               result+=result*i;

            }
            Console.WriteLine(result);
        }
    }
}
