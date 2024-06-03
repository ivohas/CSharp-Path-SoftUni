using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vacantion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day=Console.ReadLine();
            double price = 0;
            switch (day)
            {
                case "Friday":
                    if (type == "Students")
                    { 
                        price = 8.45;
                        if (count >= 30)
                        {
                            price = price - price * 15 / 100;
                        }
                    }
                    else if (type == "Business")
                    {
                        price = 10.90;
                        if (count >= 100) 
                        {
                            count = count - 10;
                        }
                    }
                    else if (type == "Regular") 
                    {
                        price = 15;
                        if (count >= 10 && count <= 20) {
                            price = price - price * 5 / 100;
                        }
                    }
                    break;
                case "Saturday":
                    if (type == "Students")
                    {
                        price = 9.80;
                        if (count >= 30)
                        {
                            price = price - price * 15 / 100;
                        }
                    }
                    else if (type == "Business")
                    {
                        price = 15.60;
                        if (count >= 100)
                        {
                            count = count - 10;
                        }
                    }
                    else if (type == "Regular")
                    {
                        price = 20;
                        if (count >= 10 && count <= 20)
                        {
                            price = price - price * 5 / 100;
                        }
                    }
                    break;
                case "Sunday":
                    if (type == "Students")
                    {
                        price = 10.46;
                        if (count >= 30)
                        {
                            price = price - price * 15 / 100;
                        }
                    }
                    else if (type == "Business")
                    {
                        price = 16;
                        if (count >= 100)
                        {
                            count = count - 10;
                        }
                    }
                    else if (type == "Regular")
                    {
                        price = 22.5;
                        if (count >= 10 && count <= 20)
                        {
                            price = price - price * 5 / 100;
                        }
                    }
                    break;
                default:
                    break;
                   
            } 
            double end = price * count;
                    Console.WriteLine($"Total price: {end:f2}");
        }
    }
}
