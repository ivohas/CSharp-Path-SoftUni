using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day= int.Parse(Console.ReadLine());
            int kilos= int.Parse(Console.ReadLine());   
            double food1= double.Parse(Console.ReadLine());
            double food2= double.Parse(Console.ReadLine());
            double food3= double.Parse(Console.ReadLine());
            double sum = (double)day * (food1 + food2 + food3);double a;
            if (kilos>=sum)
            { a = kilos - sum;a = Math.Floor (a);
                Console.WriteLine($"{a} kilos of food left.");
            }
            else
            {
                a = sum - kilos;a= Math.Ceiling (a);
                Console.WriteLine( $"{a} more kilos of food are needed.");
            }
        }
    }
}
