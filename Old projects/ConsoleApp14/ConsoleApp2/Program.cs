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
            var list=Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity=int.Parse(Console.ReadLine());int sum = 0;int raws = 0;
            int count = list.Count;
            while (count>=0 )
            {
                int i = 0;
                if (sum + list[i] < capacity)
                {
                    sum = +list[i];

                }
                else 
                {
                    raws++;
                    sum = 0;
                }
                



                    i++;
                count--;

            }
            Console.WriteLine(raws);
        }
    }
}
