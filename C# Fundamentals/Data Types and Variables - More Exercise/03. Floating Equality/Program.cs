using System;

namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;

                double n1 = double.Parse(Console.ReadLine());
                double n2 = double.Parse(Console.ReadLine()); 
                bool isEqual = Math.Abs(n1 - n2) < eps;

                if (isEqual)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }    

        }
    }
}
