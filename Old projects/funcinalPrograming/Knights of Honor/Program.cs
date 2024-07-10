using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Func<string,string> sirs = x => "Sir " + x;
            Console.WriteLine(string.Join("\r\n",Console.ReadLine().Split().Select(sirs).ToArray()));
        }
    }
}
