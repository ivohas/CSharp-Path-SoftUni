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
            int rent = int.Parse(Console.ReadLine());
            double statues =(double)rent- ((double)rent * 30 / 100);
            double food= (double)statues-((double)statues  * 15 / 100);
            double sound = (double)food / 2;
            double sum= rent+ statues + food+ sound;
            Console.WriteLine(sum);

        }
    }
}
