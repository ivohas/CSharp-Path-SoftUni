using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string price = Console.ReadLine();
         
            while (price != "special" || price != "regular")
            {

                double add = double.Parse(price);
                
                sum += add;
                price = Console.ReadLine();
            }
            
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                double taxes = 0;
                taxes = sum / 5;
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                double allsum = taxes + sum;
                if (price == "special")
                {
                    allsum = allsum - allsum / 10;
                }
                Console.WriteLine($"Total price: {allsum:f2}");
            


        }
    }
}
