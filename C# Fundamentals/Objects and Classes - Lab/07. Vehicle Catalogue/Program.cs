using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Vehicle_Catalogue
{
    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePowers { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split('/', StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArgs[0];
                string brand = cmdArgs[1];
                string model = cmdArgs[2];
                if (type == "Car")
                {
                    int horsePowers = int.Parse(cmdArgs[3]);

                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePowers = horsePowers
                    };

                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(cmdArgs[3]);

                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };

                    trucks.Add(truck);
                }
                command = Console.ReadLine();
            }

            cars = cars.OrderBy(x => x.Brand).ToList();
            trucks = trucks.OrderBy(x => x.Brand).ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePowers}hp");
                }
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
