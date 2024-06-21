using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] arrayOfStrings= Console.ReadLine().Split(' ').ToArray();
            Array.Reverse (arrayOfStrings);
            Console.WriteLine(string.Join(" ",arrayOfStrings));
        }
    }
}
