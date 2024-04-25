using System;
using System.Collections.Generic;
using System.Linq;

namespace Enter_Numbers
{
    internal class Program
    {
        static void Main()
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();
            int st = start;
            int counter = 0;
            while (counter < 10)
            {
                int number;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid Number!");
                }
                else if (!(st < number && number < end))
                {
                    Console.WriteLine($"Your number is not in range {st} - {end}!");
                }
                else
                {
                    numbers.Add(number);
                    st = number;
                    counter++;
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
