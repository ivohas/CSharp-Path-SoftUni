using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age= int.Parse(Console.ReadLine());
            double grade= double.Parse(Console.ReadLine());
            Console.WriteLine($" Name: {name}, Age: {age}, Grade: {grade:f2}");
        }
    }
}
