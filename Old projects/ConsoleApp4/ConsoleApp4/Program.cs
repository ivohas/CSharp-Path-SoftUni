using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"

            };
            int day = int.Parse(Console.ReadLine());
            day --;
            if (day < 7&&day>=0)
            {
                Console.WriteLine(array[day]);
            }
            else 
            {           
                Console.WriteLine("Invalid day!");
            }
            
        }
    }
}
