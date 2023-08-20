using System;
using System.Linq;
namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine(1);

            if (rows == 1)
            {
                return;
            }
            if (rows == 2)
            {
                Console.WriteLine("1 1");
                return;
            }

            int[] firstArray = new int[] { 1, 1 };

            Console.WriteLine(string.Join(" ", firstArray));

            for (int i = 2; i < rows; i++)
            {
                int[] secondArray = new int[firstArray.Length + 1]; // (3)

                for (int j = 1; j < secondArray.Length - 1; j++)
                {
                    secondArray[0] = 1;
                    secondArray[secondArray.Length - 1] = 1;

                    secondArray[j] = firstArray[j - 1] + firstArray[j];
                }
                Console.WriteLine(string.Join(" ", secondArray));
                firstArray = secondArray;
            }
        }
    }
}