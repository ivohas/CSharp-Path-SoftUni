using System;


namespace devided_by_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 3; i <100; i=i+3)
            {
                Console.WriteLine(i);
                sum += i;
            }
            Console.WriteLine("Sum: "+sum);
        }
    }
}
