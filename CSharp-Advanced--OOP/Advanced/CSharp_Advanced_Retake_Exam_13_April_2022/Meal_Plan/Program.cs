using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split();
            int[] calories = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<string> mealQ = new List<string>(meals.Reverse());
            int mealCount = mealQ.Count;
            List<int> dailyCQ = new List<int>(calories);
            
            while (dailyCQ.Count > 0 && mealQ.Count > 0)
            {
                string product = mealQ[mealQ.Count - 1];
                int dailyCalories = dailyCQ[dailyCQ.Count - 1];

                int mealCalories = 0;
                if (product == "salad")
                {
                    mealCalories = 350;
                }
                else if (product == "soup")
                {
                    mealCalories = 490;
                }
                else if (product == "pasta")
                {
                    mealCalories = 680;
                }
                else if (product == "steak")
                {
                    mealCalories = 790;
                }

                if (dailyCalories > mealCalories)
                {
                    dailyCalories -= mealCalories;
                    dailyCQ[dailyCQ.Count - 1] = dailyCalories;
                    mealQ.RemoveAt(mealQ.Count - 1);
                    if (dailyCalories == 0)
                    {
                        dailyCQ.RemoveAt(dailyCQ.Count - 1);
                    }
                }
                else
                {
                    mealCalories = Math.Abs(dailyCalories - mealCalories);
                    dailyCQ.RemoveAt(dailyCQ.Count - 1);

                    if (dailyCQ.Count > 0)
                    {
                        dailyCalories = dailyCQ[dailyCQ.Count - 1];
                        //if (mealQ.Count > 0)
                        //{
                        //    mealQ.RemoveAt(mealQ.Count - 1);
                        //    dailyCalories -= mealCalories;
                        //    dailyCQ[dailyCQ.Count - 1] = dailyCalories;
                        //}
                    }
                    if (mealQ.Count > 0)
                    {
                        mealQ.RemoveAt(mealQ.Count - 1);
                        dailyCalories -= mealCalories;
                        if (dailyCQ.Count > 0)
                        {
                            dailyCQ[dailyCQ.Count - 1] = dailyCalories;

                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            dailyCQ.Reverse();
            if (mealQ.Count == 0)
            {
                Console.WriteLine($"John had {mealCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCQ)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCount -= mealQ.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(" ", mealQ)}.");
            }
        }
    }
}
