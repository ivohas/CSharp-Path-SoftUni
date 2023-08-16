using System;
using System.Linq;
namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] firstArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] arraySum = new string[firstArray.Length];


            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int k = 0; k < secondArray.Length; k++)
                {
                    if (firstArray[i] == secondArray[k])
                    {
                        Console.Write(firstArray[i]+ " ");
                    }
                }
            }

        }
    }
}
