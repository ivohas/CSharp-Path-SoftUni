using System;
using System.Linq;
namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] topIntegers = new int[array.Length];
            int topIntegersIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isTopInteger = true;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] >= array[i])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    topIntegers[topIntegersIndex++] = array[i];
                }
            }

            for (int k = 0; k < topIntegersIndex; k++)
            {
                Console.Write(topIntegers[k] + " ");
            }
        }
    }
}
