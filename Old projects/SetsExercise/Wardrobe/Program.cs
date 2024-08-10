using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrope = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                //"Blue -> dress,jeans,hat".Split(" -> ") -> ["Blue", "dress,jeans,hat"]
                string color = input.Split('-','>')[0].Trim();Console.WriteLine(color);
            }
            
        }
    }
}
