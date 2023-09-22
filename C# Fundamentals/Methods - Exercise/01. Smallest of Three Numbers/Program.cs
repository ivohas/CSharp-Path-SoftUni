using System;
using System.Linq;
namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            int smallestNumber = GetSmallestNumber(number1, number2, number3);

            Console.WriteLine(smallestNumber);
        }

        static int GetSmallestNumber(int number1, int number2, int number3)
        {
            int[] array = new int[3];
            
            array[0] = number1;
            array[1] = number2;
            array[2] = number3;

            int smallestNumber = array.Min();

            return smallestNumber;
        }
    }
}
