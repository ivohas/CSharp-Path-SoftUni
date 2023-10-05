using System;

namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            RectangleArea(a, b);
        }

        static void RectangleArea(int a, int b)
        {
            int sum = a * b;

            Console.WriteLine(sum);
        }
    }
}
