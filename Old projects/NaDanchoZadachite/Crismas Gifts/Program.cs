using System;
using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int kidsCount = 0;
        int adultsCount = 0;
        int toysCost = 0;
        int sweatersCost = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Christmas")
                break;

            if (int.TryParse(input, out int age))
            {
                if (age <= 16)
                {
                    kidsCount++;
                    toysCost += 5;
                }
                else
                {
                    adultsCount++;
                    sweatersCost += 15;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid age.");
            }
        }

        Console.WriteLine($"Number of adults: {adultsCount}");
        Console.WriteLine($"Number of kids: {kidsCount}");
        Console.WriteLine($"Money for toys: {toysCost}");
        Console.WriteLine($"Money for sweaters: {sweatersCost}");
    }
}
