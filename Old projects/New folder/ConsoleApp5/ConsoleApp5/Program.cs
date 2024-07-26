using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var dalzhinarabotnimesata = Math.Round(width / 1.20);
            var shirochinarabotnimesta = Math.Round((height - 1) / 0.70);
            var zaguba = 3;

            var obsto = (dalzhinarabotnimesata * shirochinarabotnimesta) - 3;

            Console.WriteLine($"{obsto}");
        }
    }
}
