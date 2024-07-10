using System;
using System.Collections.Generic;
using System.Linq;

namespace mealplan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split().ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<string> meals = new Queue<string>(firstLine);
            Stack<int> caloriesPerDay = new Stack<int>(secondLine);
            while (caloriesPerDay.Count > 0 && meals.Count > 0)
            {
                string meal = meals.Peek();
                meals.Dequeue();
                int cal = caloriesPerDay.Pop();
                int calPerMeal = 0;
                switch (meal)
                {
                    case "salad":

                        calPerMeal += 350;
                        break;
                    case "soup":
                        calPerMeal += 490;
                        break;
                    case "steak":
                        calPerMeal += 790;
                        break;
                    case "pasta":
                        calPerMeal += 680;
                        break;
                }
                if (cal >= calPerMeal)
                {
                    int n = cal - calPerMeal;
                    if (n == 0)
                    {

                    }
                    else
                    {
                        caloriesPerDay.Push(n);
                    }
                }
                else
                {
                    calPerMeal -= cal;

                }

            }
            if (meals.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {firstLine.Length - meals.Count} meals.");
                Console.WriteLine("Meals left: " + String.Join(", ", meals) + ".");
            }
            else
            {
                Console.WriteLine($"John had {firstLine.Length} meals.");
                Console.WriteLine("For the next few days, he can eat " + String.Join(", ", caloriesPerDay) + " calories.");
            }
        }
    }
}