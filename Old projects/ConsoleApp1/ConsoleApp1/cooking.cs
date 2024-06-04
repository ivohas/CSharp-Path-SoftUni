using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]firstLine=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[]secondLine=Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int>liquid=new Queue<int>(firstLine);
            Stack<int>ingridiats=new Stack<int>(secondLine);
            Dictionary<string, int> counter = new Dictionary<string, int>();
            counter.Add("Bread", 0);
            counter.Add("Cake", 0); 
            counter.Add("Fruit Pie", 0);
            counter.Add("Pastry", 0);
           

            
            while (ingridiats.Count>0&&liquid.Count>0)
            {
                int amountOfLiquid = liquid.Peek();
                liquid.Dequeue();
                int ingridians = ingridiats.Pop();
                int sum = ingridians + amountOfLiquid;
                if (sum==25)
                {
                    counter["Bread"] += 1;
                }
                else if (sum==50)
                {
                    counter["Cake"] += 1;
                }
                else if (sum==75)
                {
                    counter["Pastry"] += 1;
                }
                else if (sum==100)
                {
                    counter["Fruit Pie"] += 1;
                }
                else
                {
                    ingridians += 3;
                    ingridiats.Push(ingridians);
                }




            }
            
           
           int n= counter.Count(x => x.Value > 0);
            if (n==4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            int check1 = liquid.Sum();
            if (check1 == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: " + String.Join(", ", liquid));
            }
            int check = ingridiats.Sum();
            if (check == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else 
            {
                Console.WriteLine("Ingredients left: "+String.Join(", ",ingridiats) );
            }


            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
