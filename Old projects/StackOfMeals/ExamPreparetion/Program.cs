using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparetion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split().ToArray();
            int[] caloiesPerDay = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int salad = 350;
            int soup = 490;
            int pasta = 680;
            int steak = 790;
            int maxCal = 0;
            foreach (var item in caloiesPerDay)
            {
                maxCal += item;
            }
            int sum = 0;

            foreach (var item in meals)
            {
                switch (item)
                {
                    case "salad":
                        sum += salad;
                        break;
                    case "pasta":
                        sum += pasta;
                        break;
                    case "soup":
                        sum += soup;
                        break;
                    case "steak":
                        sum += steak;
                        break;
                    default:
                        break;

                }
            }
            if (sum >maxCal)
            {
                int a = 0;
                int leftCal = sum - maxCal;
                meals.Reverse();
                List<string> names = new List<string>();
                for (int i = 0; i < meals.Length; i++)
                {
                    if (meals[i]=="steak")
                    {
                        a = steak;

                    }
                    else if (meals[i]=="soup")
                    {
                        a = soup;
                    }
                    else if (meals[i] == "salad")
                    {
                        a = salad;
                    }
                    else if (meals[i] == "pasta")
                    {
                        a = pasta;
                    }


                    if (leftCal > a)
                    {
                        leftCal -= a;
                       

                    }
                    else 
                    {
                        names.Add(meals[i]);
                        break;
                    }
                }
                Console.WriteLine($"John ate enough, he had {meals.Length-names.Count} meals.");
                Console.WriteLine("Meals left: "+string.Join(" ",names )+".");
            }
        }
    }
}
