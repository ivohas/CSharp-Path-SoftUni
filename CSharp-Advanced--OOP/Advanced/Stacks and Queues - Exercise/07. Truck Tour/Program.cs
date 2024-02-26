using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Pump
    {
        public int petrol { get; set; }
        public int distance { get; set; }

        public Pump(int petrol, int distance)
        {
            this.petrol = petrol;
            this.distance = distance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var petrol = new Queue<int>();
            var distance = new Queue<int>();
            int[] input;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                petrol.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }
            int currentFuel;
            var petrolCopy = new Queue<int>();
            var distanceCopy = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                currentFuel = petrol.Peek();
                for (int x = 0; x < n; x++)
                {
                    if (distance.Peek() <= currentFuel)
                    {
                        currentFuel -= distance.Peek();
                        if (x == n - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }
                    }
                    else
                    {
                        for (int y = x; y < n; y++)
                        {
                            petrol.Enqueue(petrol.Dequeue());
                            distance.Enqueue(distance.Dequeue());
                        }
                        break;
                    }
                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                    currentFuel += petrol.Peek();
                }
                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }

        }
    }
}
