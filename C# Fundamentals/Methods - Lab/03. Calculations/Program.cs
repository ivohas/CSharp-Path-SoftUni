using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Action(a, b, action);
        }
        static void Action(int a, int b, string action)
        {
            int sum = 0;
            if (action == "add")
            {
                sum = a + b;
            }
            else if (action == "multiply")
            {
                sum = a * b;
            }
            else if (action == "substract")
            {
                sum = a - b;
            }
            else if (action == "divide")
            {
                sum = a / b;
            }

            Console.WriteLine(sum);
        }
    }
}
