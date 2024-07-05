using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addingVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal,decimal> Vat = x => x * 1.20m;
            Console.WriteLine(string.Join("\r\n ", Console.ReadLine().Split(',').Select(x => x.Trim()).Select(decimal.Parse).Select(Vat).Select(x=>Math.Round(x,2)).ToList())); 


        }
    }
}
