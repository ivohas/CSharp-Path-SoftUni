using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[]array=new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++) 
            {
                array[i]= int.Parse(Console.ReadLine());
                sum+=array[i];
            }
            Console.WriteLine(String.Join(" ",array));
            Console.WriteLine(sum);
        }
    }
}
