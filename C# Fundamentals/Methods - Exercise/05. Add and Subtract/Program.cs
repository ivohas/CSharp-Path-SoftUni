using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = Sum(a, b, c);
            sum = Substraction(sum, c);
            Console.WriteLine(sum);
        }

        static int Sum(int a, int b, int c)
        {
            int sum = a + b;

            return sum;
        }

        static int Substraction(int sum, int c)
        {
            sum -= c;

            return sum;
        }
    }
}
