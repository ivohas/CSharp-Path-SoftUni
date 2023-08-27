using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int sum = 0;

            Console.Write(start + " ");

            for (int i = start; i < end; i++)
            {
                sum += start;
                start++;
                Console.Write(start + " ");
            }
            Console.WriteLine();
            sum += start;
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
