using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().ToArray();int sum = 0;
            for (int i = 1; i < list.Length / 2 ; i++)
                
            {
                string b = list[i];
                
                int a = int.Parse(list[i]);
                 sum =+a;
                if (b=="-")
                {
                    sum = sum - 2;
                }
            }
            sum =+int.Parse(list[0]);
        }
    }
}
