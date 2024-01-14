using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main()
        {
            int[] whiteT = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] grayT = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // locatuins for tiles
            Dictionary<string, int> locsTiles = new Dictionary<string, int>()
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0},
            };

            //locations
            Dictionary<int, string> locs = new Dictionary<int, string>()
            {
                { 40, "Sink" },
                { 50, "Oven" },
                { 60, "Countertop" },
                { 70, "Wall" },

            };

            Stack<int> whiteTQ = new Stack<int>(whiteT);
            Queue<int> grayTQ = new Queue<int>(grayT);

            while (whiteTQ.Count > 0 && grayTQ.Count > 0)
            {
                int currWT = whiteTQ.Peek();
                int currGT = grayTQ.Peek();

                if (currGT.Equals(currWT))
                {
                    int largerTile = whiteTQ.Peek() + grayTQ.Peek();
                    if (locs.ContainsKey(largerTile))
                    {
                        grayTQ.Dequeue();
                        whiteTQ.Pop();
                        locsTiles[locs[largerTile]]++;
                    }
                    else
                    {
                        grayTQ.Dequeue();
                        whiteTQ.Pop();
                        locsTiles["Floor"]++;
                    }
                }
                else
                {
                    whiteTQ.Pop();
                    currWT /= 2;
                    whiteTQ.Push(currWT);

                    grayTQ.Enqueue(currGT);
                    grayTQ.Dequeue();
                }
            }

            if (whiteTQ.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTQ)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (grayTQ.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTQ)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            //just tried it :D
            goto HERE;
            HERE:
            foreach (var loc in locsTiles.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                if (loc.Value > 0)
                {
                    Console.WriteLine($"{loc.Key}: {loc.Value}");
                }
            }
        }
    }
}
