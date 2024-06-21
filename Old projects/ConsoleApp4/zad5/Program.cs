using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumOfEven = 0;
            int sumOfOdd = 0;
            int []array= Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i <array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumOfEven += array[i];
                }
                else
                {
                    sumOfOdd += array[i];
                }
                
            }
            Console.WriteLine(sumOfEven-sumOfOdd);
        }
    }
}
