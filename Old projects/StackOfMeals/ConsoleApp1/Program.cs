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
            string[] meals = Console.ReadLine().Split().ToArray();
            List<int> calPerMeal = new List<int>();
            foreach (var item in meals)
            {
                int intake=0;
                if (item=="salad")
                {
                    intake = 350;
                }
                else if (item=="steak")
                {
                    intake = 790;
                }
                else if (item=="soup")
                {
                    intake = 490;
                }
                else if(item=="pasta")
                {
                    intake = 680;
                }
                calPerMeal.Add(intake);

            }
            List<int> dayDose = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> days = new Queue<int>();
            foreach (var item in dayDose)
            {
                days.Enqueue(item);
            }
            int i = 0;
            foreach (var item in days)
            {
                
                int a = days.Peek();
                if (a > calPerMeal[i])
                {
                    a = a - calPerMeal[i];
                    i++;
                }
                else
                {
                    calPerMeal[i] -= a;
                    days.Dequeue();
                }
                
            }

            if (days.Count>0)
            {
                Console.WriteLine($"John had {days.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(" ",days)} calories");

            }
            else
            {
                Console.WriteLine($"John ate enough, he had {i} meals.");
                Console.WriteLine("Meals left:");
            }
            
        }
    }
}
