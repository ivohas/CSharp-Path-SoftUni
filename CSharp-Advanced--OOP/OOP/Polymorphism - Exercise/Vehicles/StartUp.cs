using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split().Skip(1).ToArray();
            double carFuelQuantity = double.Parse(carInfo[0]);
            double carFuelConsumption = double.Parse(carInfo[1]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine().Split().Skip(1).ToArray();
            double truckFuelQuantity = double.Parse(truckInfo[0]);
            double truckFuelConsumption = double.Parse(truckInfo[1]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double distance = double.Parse(cmdArgs[2]);

                if (vehicleType == "Car")
                {
                    if (cmdType == "Drive")
                    {
                        car.Drive(distance);
                    }
                    else if (cmdType == "Refuel")
                    {
                        car.Refuel(distance);
                    }
                }
                else if (vehicleType == "Truck")
                {
                    if (cmdType == "Drive")
                    {
                        truck.Drive(distance);
                    }
                    else if (cmdType == "Refuel")
                    {
                        truck.Refuel(distance);
                    }
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
        }
    }
}
