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
         double a =double.Parse( Console.ReadLine ());
            double pr = 7.61;
            double b = a * pr;
            double c = b * 0.18;
            double d = b - c;
            Console.WriteLine("The final price is: " + d);
            Console.WriteLine("The discount is: "+ c);
        }
    }
}
