using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main()
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            double carHP = 0;
            double truckHP = 0;

            int carsNeeded = 0;
            int trucksNeeded = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ').ToArray();

                string typeOfVehicle = cmdArgs[0];
                string model = cmdArgs[1];
                string color = cmdArgs[2];
                string horsePowers = cmdArgs[3];

                if (typeOfVehicle == "truck")
                {
                    Truck truck = new Truck(model, color, horsePowers);
                    trucks.Add(truck);
                    trucksNeeded++;
                    truckHP += double.Parse(horsePowers);
                }
                else if (typeOfVehicle == "car")
                {
                    Car car = new Car(model, color, horsePowers);
                    cars.Add(car);
                    carsNeeded++;
                    carHP += double.Parse(horsePowers);
                }

            }


            string carModel;
            while ((carModel = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        Console.WriteLine(car);
                        continue;
                    }
                }

                foreach (Truck truck in trucks)
                {
                    if (truck.Model == carModel)
                    {
                        Console.WriteLine(truck);
                    }
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carHP / carsNeeded:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckHP / trucksNeeded:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    class Car
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string HorsePowers { get; set; }

        public Car(string model, string color, string horsePowers)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePowers = horsePowers;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: Car");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePowers}");

            return sb.ToString().TrimEnd();
        }
    }

    class Truck
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string HorsePowers { get; set; }

        public Truck(string model, string color, string horsePowers)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePowers = horsePowers;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: Truck");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePowers}");

            return sb.ToString().TrimEnd();
        }
    }
}
