using System;
using System.Collections.Generic;

namespace _6._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string model = cmdArgs[0];
                double fuelAmount = double.Parse(cmdArgs[1]);
                double fuelConsumption = double.Parse((cmdArgs[2]));

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            string[] tokens = Console.ReadLine().Split();
            while (tokens[0] != "End")
            {
                if (tokens[0] == "Drive")
                {
                    string model = tokens[1];
                    Car currCar = cars.Find(c => c.Model.Equals(model));
                    double distance = double.Parse(tokens[2]);
                    currCar.Drive(distance);
                }
                tokens = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}