using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season=Console.ReadLine();double prize;double sum;
            if (people>5)
            {
                switch (season)
                {
                    case "winter":
                        prize = 86;
                        sum = people*prize+(people * prize)*8/100;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "summer":
                        prize = 48.5;
                        sum = people * prize - (people * prize) * 15 / 100;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "autumn":
                        prize = 60;
                        sum = people * prize;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "spring":
                        prize = 50;
                        sum = people * prize;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                        default:break;



                }
            }
            else
            {
                switch (season)
                {
                    case "winter":
                        prize = 85;
                        sum = people * prize + (people * prize) * 8 / 100;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "summer":
                        prize = 45;
                        sum = people * prize - (people * prize) * 15 / 100;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "autumn":
                        prize = 49.5;
                        sum = people * prize;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    case "spring":
                        prize = 48;
                        sum = people * prize;
                        Console.WriteLine($"{sum:f2}leva.");
                        break;
                    default: break;



                }
            }
        }
    }
}
