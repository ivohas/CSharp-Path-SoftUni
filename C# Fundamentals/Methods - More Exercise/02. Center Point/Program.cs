using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            PrintClosestCoordinates(x1, y1, x2, y2);
        }

        static void PrintClosestCoordinates(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1) + Math.Abs(y1) < Math.Abs(x2) + Math.Abs(y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (Math.Abs(x1) + Math.Abs(y1) > Math.Abs(x2) + Math.Abs(y2))
            {
                Console.WriteLine($"({x2}, {y2})");

            }
            else if (Math.Abs(x1) + Math.Abs(y1) == Math.Abs(x2) + Math.Abs(y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
