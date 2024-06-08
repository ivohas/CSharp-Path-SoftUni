using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integers= Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var dict= new Dictionary<double,int>();
            foreach (var item in integers)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else 
                { 
                    dict[item]=1;
                }
            }
            foreach (var item in dict)
            {

                Console.WriteLine($"{dict.Keys} - {dict.Values} times");
            }
        }
    }
}
