using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', 6)
                    .ToArray();
                var engine = new Engine();
                var cargo = new Cargo();
                var tires = new List<Tire>();
                string model = input[0];
                engine.Speed = int.Parse(input[1]);
                engine.Power = int.Parse(input[2]);
                cargo.Weight = int.Parse(input[3]);
                cargo.Type = input[4];
                var splitTires = input[5].Split(' ').ToArray();

                for (int j = 0; j < splitTires.Length; j += 2)
                {
                    var tire = new Tire();
                    tire.TirePressure = double.Parse(splitTires[j]);
                    tire.TireAge = int.Parse(splitTires[j + 1]);
                    tires.Add(tire);
                }
                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    DisplayFragile(cars);
                    break;
                case "flammable":
                    DisplayFlamable(cars);
                    break;
            }
        }

        static void DisplayFragile(List<Car> cars)
        {
            foreach (var car in cars)
            {
                string model = string.Empty;
                foreach (var tire in car.TireList)
                {

                    if (tire.TirePressure < 1 && car.Model != model)
                    {
                        model = car.Model;
                        Console.WriteLine($"{car.Model}");
                    }
                }

            }
        }

        static void DisplayFlamable(List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (car.Engine.Power > 250)
                    Console.WriteLine($"{car.Model}");
            }
        }
    }
}
