using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]array=Console.ReadLine().Split(',').Select(n=>n=n.Trim()).Select(n => int.Parse(n)).ToArray();
            
           int sum= array.Sum();
            int lenght= array.Length;
            Console.WriteLine(lenght );
            Console.WriteLine(sum);
        }
    }
}
