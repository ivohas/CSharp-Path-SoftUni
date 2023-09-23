using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());

            double result = Operator(a, @operator, b);
            Console.WriteLine(result);
        }

        static double Operator(double a, char @operator, double b)
        {
            double result = 0;
            switch (@operator)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                        result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
