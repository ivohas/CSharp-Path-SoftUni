using System;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listOfNums = Console.ReadLine()
                                         .Split();

            for (int i = listOfNums.Length - 1; i >= 0; i--)
            {
                Console.Write(listOfNums[i] + " ");
            }

        }
    }
}
