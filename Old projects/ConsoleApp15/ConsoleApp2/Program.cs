using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array= Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x=>x).ToList();
            for (int i = 0; i < 3; i++)
            {
                if (i<array.Count )
                {
                    Console.Write(array[i]+" ");
                }
            }
           
        }
    }
}
