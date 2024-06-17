using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            int first = 1, second = 1, f;
            int nesto = n - 1;
           while(!(first>=n&&second>=n))
            { Console.WriteLine(first+" "+second);
                Console.WriteLine(first+second);
                second++;
                if (second==n)
                {
                    first++;
                    second = 1;
                }
               
                
            }
        }
    }
}
