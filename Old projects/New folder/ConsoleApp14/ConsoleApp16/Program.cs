using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vavedi pocivni dni: ");
            int a= int.Parse(Console.ReadLine());
            int b = 365;
            int c = 365 - a;
            int d = c * 63 + a * 127;
            int need = 30000;
            int result;int hours;int minute;
            if (a > need)
            {
                Console.WriteLine("Tom will run awey");
                result = a - need;
                if (result>60)
                {
                    hours = result / 60;
                    minute = result % 60;
                    Console.WriteLine(hours+" hours and" + minute+" minutes more to play");
                }
                else
                {
                    Console.WriteLine("Tom sleeps well");
                    hours = result / 60;
                    minute = result % 60;
                    Console.WriteLine(hours + " hours and" + minute + " minutes less for play");
                }
            }
        }
    }
}
