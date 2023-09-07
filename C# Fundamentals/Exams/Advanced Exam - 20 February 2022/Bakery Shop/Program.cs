using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bakery = new Dictionary<string, int>
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };

            double[] w = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] f = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(w);
            Stack<double> flour = new Stack<double>(f);

            double flourForCroissant;
            while (water.Any() && flour.Any())
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();

                double[] ratios = Ratios(currWater, currFlour);
                double waterRatio = ratios[0];
                double flourRatio = ratios[1];

                bool cooked = false;
                if (Croissant(waterRatio, flourRatio))
                {
                    bakery["Croissant"]++;
                    cooked = true;
                }
                else if (Muffin(waterRatio, flourRatio))
                {
                    bakery["Muffin"]++;
                    cooked = true;
                }
                else if (Baguette(waterRatio, flourRatio))
                {
                    bakery["Baguette"]++;
                    cooked = true;
                }
                else if (Bagel(waterRatio, flourRatio))
                {
                    bakery["Bagel"]++;
                    cooked = true;
                }
                else
                {
                    bakery["Croissant"]++;
                    cooked = false;

                    flourForCroissant = currWater;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(currFlour - flourForCroissant);
                }

                if (cooked)
                {
                    water.Dequeue();
                    flour.Pop();
                }
            }

            foreach (var item in bakery.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            if (water.Any())
                 Console.WriteLine($"Water left: {string.Join(", ", water)}");
            else Console.WriteLine($"Water left: None");

            if (flour.Any())
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            else Console.WriteLine($"Flour left: None");

        }

        public static bool Croissant(double waterRatio, double flourRatio)
        {
            if (waterRatio == 50 && flourRatio == 50)
                return true;

            return false;
        }
        public static bool Muffin(double waterRatio, double flourRatio)
        {
            if (waterRatio == 40 && flourRatio == 60)
                return true;

            return false;
        }

        public static bool Baguette(double waterRatio, double flourRatio)
        {
            if (waterRatio == 30 && flourRatio == 70)
                return true;

            return false;
        }

        public static bool Bagel(double waterRatio, double flourRatio)
        {
            if (waterRatio == 20 && flourRatio == 80)
                return true;

            return false;
        }
        public static double[] Ratios(double water, double flour)
        {
            double[] returner = new double[2];
            double sum = water + flour;

            returner[0] = Math.Round(water / sum * 100, MidpointRounding.AwayFromZero);
            returner[1] = Math.Round(flour / sum * 100, MidpointRounding.AwayFromZero);

            return returner;
        }
    }
}
