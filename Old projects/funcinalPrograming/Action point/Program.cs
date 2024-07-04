using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var list = Console.ReadLine().Split().ToList();
            foreach(var item in list)
                Console.WriteLine(item);
        }
    }
}
