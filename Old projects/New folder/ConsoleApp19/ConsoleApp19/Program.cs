using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maz = int.Parse(Console.ReadLine());
            int pro=int.Parse(Console.ReadLine());
            int vag=int.Parse(Console.ReadLine());
            int cal =int.Parse(Console.ReadLine());
            int water= int.Parse(Console.ReadLine()); 
            double a = ((double)cal *(double) maz / 100) / 9;
            double b = ((double)cal * (double)pro / 100) / 4;
            double c = ((double)cal * (double)vag / 100 / 4);
            double d = a + b + c;
            double e = cal / d;
            double pr = 100 - water;
            double sum = e * pr / 100;
            Console.WriteLine($"{sum:f4}");
        }
    }
}
