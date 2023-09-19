using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_III
{
    class Car
    {
        public string CarName { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public Car(string carName, int mileage, int fuel)
        {
            this.CarName = carName;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{CarName} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }

    }

    internal class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] Args = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string carName = Args[0];
                int mileage = int.Parse(Args[1]);
                int fuel = int.Parse(Args[2]);

                Car car = new Car(carName, mileage, fuel);
                cars.Add(car);

            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmdType = cmdArgs[0];
                string carName = cmdArgs[1];

                if (cmdType == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);
                    Drive(cars, carName, distance, fuel);

                }
                else if (cmdType == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    Refuel(cars, carName, fuel);
                }
                else if (cmdType == "Revert")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    Revert(cars, carName, distance);
                }

            }

            foreach (Car vehicle in cars)
            {
                Console.WriteLine(vehicle);
            }
        }

        static void Drive(List<Car> cars, string carName, int distance, int fuel)
        {
            if (fuel <= cars.Find(c => c.CarName == carName).Fuel)
            {
                Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                cars.Find(c => c.CarName == carName).Fuel -= fuel;
                cars.Find(c => c.CarName == carName).Mileage += distance;
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            if (cars.Find(c => c.CarName == carName).Mileage >= 100000)
            {
                Console.WriteLine($"Time to sell the {carName}!");
                cars.Remove(cars.Find((c) => c.CarName == carName));
            }
        }

        static void Refuel(List<Car> cars, string carName, int fuel)
        {

            if (cars.Find(c => c.CarName == carName).Fuel + fuel > 75)
            {
                fuel = 75 - cars.Find(c => c.CarName == carName).Fuel;
            }
            cars.Find(c => c.CarName == carName).Fuel += fuel;


            Console.WriteLine($"{carName} refueled with {fuel} liters");
        }

        static void Revert(List<Car> cars, string carName, int distance)
        {
            cars.Find(c => c.CarName == carName).Mileage -= distance;
            if (cars.Find(c => c.CarName == carName).Mileage >= 10000)
            {
                Console.WriteLine($"{carName} mileage decreased by {distance} kilometers");

            }
            else
            {
                cars.Find(c => c.CarName == carName).Mileage = 10000;
            }
        }

    }
}
