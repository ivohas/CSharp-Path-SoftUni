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
            string[] first = Console.ReadLine()
                .Split();

            string[] second = Console.ReadLine()
                .Split();

            string result = "";

            foreach (var kvp in second)
            {
                if (first.Contains(kvp))
                {
                    result += " " + kvp;
                    //Console.Write($" {kvp}");
                }
            }

            Console.Write($"{result.Trim()}");
        }
    }
}
