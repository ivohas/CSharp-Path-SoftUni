using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int st = int.Parse(Console.ReadLine());
            double grade= double.Parse(Console.ReadLine());
            int dve = 0,tri=0,four=0,five=0;
            do
            {
                st--;
                if (grade<=2.99)
                {
                    dve++;
                }else if (grade <= 3.99)
                {
                    tri++;
                }
                else if (grade <= 4.99) { four++; } else { five++; }

            } while (st != 0);
            double a = five / st * 100;
            Console.WriteLine($"Top student: {a}%");
        }
    }
}
