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
            
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrayOfSums = new int[array.Length - 1];int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {   if (array[i] != array.Length)
                { arrayOfSums[i] = array[i] + array[i + 1];

                }
                
            }
            for (int i = 0; i < arrayOfSums.Length ; i++)
            {
                sum += arrayOfSums[i]; 
            }
            Console.WriteLine(sum);
        }
    }
}
