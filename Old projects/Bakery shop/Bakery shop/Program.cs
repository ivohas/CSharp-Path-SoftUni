using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> water = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> flavour = Console.ReadLine().Split().Select(double.Parse).ToList();
            Dictionary<string, double> proportions = new Dictionary<string, double>();
            proportions.Add("Croissant", 0.5);
            proportions.Add("Muffin", 0.4);
            proportions.Add("Baguette", 0.3);
            proportions.Add("Bagel", 0.2);
            flavour.Remove 

        }
    }
}
