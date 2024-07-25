using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double prize = double.Parse(Console.ReadLine());
            double decor = money / 10;
            double d = prize * statist; double a;
            if (statist >= 150)
            {
                d = d - d / 10;
            }
            double sum = d + decor;
            if (sum <= money)
            {
                a = money - sum;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {a:f2} leva left.");

            }
            else
            { a = sum - money;
                Console.WriteLine(" Not enough money!");
                Console.WriteLine($"Wingard needs {a:f2} leva more."); 
            }
        }
    } 
}
