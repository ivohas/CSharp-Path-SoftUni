using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcinalPrograming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int>integers= Console.ReadLine().Split(',').Select(n=>int.Parse(n)).Where(x => x % 2 == 0) .OrderBy(x=>x).ToList();
            Console.WriteLine(String.Join(", ",integers));
            
        }
    }
}
