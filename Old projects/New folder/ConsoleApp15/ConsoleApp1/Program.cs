using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            string a= Console.ReadLine();
            int money= int.Parse(Console.ReadLine());int b;int sum;
            do
            {
                do
                {
                    b = int.Parse(Console.ReadLine());
                    sum = +b;
                    b = 0;

                } while (sum > money);
                sum = 0;
                Console.WriteLine("Going to " + a + "!");
                a = Console.ReadLine();
                money = int.Parse(Console.ReadLine());

            } while (a == "End");
        }
    }
}
