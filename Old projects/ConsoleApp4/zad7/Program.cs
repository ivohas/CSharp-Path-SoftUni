using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumOfArrays = 0;int count = 0;
            int []array1= Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine($" Arrays are not identical. Found difference at {i} index");
                    break;
                }
                else 
                {
                    sumOfArrays += array1[i];
                    count++;
                }
            }
            if (count==array1.Length )
            {
                Console.WriteLine($" Arrays are identical. Sum: { sumOfArrays}");
            }

        }
    }
}
