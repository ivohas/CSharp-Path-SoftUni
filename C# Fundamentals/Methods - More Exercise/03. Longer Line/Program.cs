using System;

namespace _03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());
            int x4 = int.Parse(Console.ReadLine());
            int y4 = int.Parse(Console.ReadLine());

            PrintClosestCoordinates(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void PrintClosestCoordinates(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            if ((Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2)) > (Math.Abs(x3) + Math.Abs(y3) + Math.Abs(x4) + Math.Abs(y4)) || (Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2)) == (Math.Abs(x3) + Math.Abs(y3) + Math.Abs(x4) + Math.Abs(y4)))
            {
                if (x1 + y1 < x2 + y2 || x1 + y1 == x2 + y2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (x3 + y3 < x4 + y4 || x3 + y3 == x4 + y4)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
            }

        }
    }
}
