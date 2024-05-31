using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] firstLine = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] secondLine = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<string, int> baked = new Dictionary<string, int>();
            baked.Add("Bagel", 0);
            baked.Add("Baguette", 0);
            baked.Add("Croissant", 0);
            baked.Add("Muffin", 0);


            Queue<double> water = new Queue<double>(firstLine);
            Stack<double> flour = new Stack<double>(secondLine);
            while (water.Count > 0 && flour.Count > 0)
            {
                double portionOfWater = water.Peek();
                water.Dequeue();
                double portionOfFlour = flour.Pop();

                if (portionOfWater / portionOfFlour == 50 / 50)
                {
                    baked["Croissant"] += 1;
                }
                else if (portionOfWater * 100 / (portionOfWater + portionOfFlour) == 40)
                {
                    baked["Muffin"] += 1;
                }
                else if (portionOfWater*100/(portionOfWater + portionOfFlour) == 30 )
                {
                    baked["Baguette"] += 1;
                }
                else if (portionOfWater * 100 / (portionOfWater + portionOfFlour) == 20)
                {
                    baked["Bagel"] += 1;
                }
                else
                {
                    double a = portionOfFlour - portionOfWater;
                    portionOfFlour -= a;
                    baked["Croissant"] += 1;

                    flour.Push(a);
                }
            }
            baked.Select(x => x.Value >= 1);
            IOrderedEnumerable<KeyValuePair<string, int>> sortedCollection = baked
                .Where(x=>x.Value>0)
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);
            
            foreach (var item in sortedCollection)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            double sumOfWater = water.Sum();
            if (sumOfWater>0)
            {
                Console.WriteLine("Water left: "+ String.Join(", ",water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }



            double sumofFlavour = flour.Sum();
            if (sumofFlavour > 0)
            {
                Console.WriteLine("Flour left: "+String.Join(", ",flour ));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
