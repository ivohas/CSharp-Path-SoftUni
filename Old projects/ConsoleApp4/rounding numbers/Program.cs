using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rounding_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());
            double[] arrayOfNums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
          
            for (int i = 0; i <= count; i++)
            {
                Console.WriteLine(($"{arrayOfNums[i]}=>{Math.Round(arrayOfNums[i],MidpointRounding.AwayFromZero)}"));
            }
        }
    }
}
