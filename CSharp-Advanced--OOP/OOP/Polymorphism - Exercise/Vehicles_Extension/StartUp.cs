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
            double carTankCapacity = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInfo = Console.ReadLine().Split().Skip(1).ToArray();
            double truckFuelQuantity = double.Parse(truckInfo[0]);
            double truckFuelConsumption = double.Parse(truckInfo[1]);
            double truckTankCapacity = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split().Skip(1).ToArray();
            double busFuelQuantity = double.Parse(busInfo[0]);
            double busFuelConsumption = double.Parse(busInfo[1]);
            double busTankCapacity = double.Parse(busInfo[2]);
            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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
                else if (vehicleType == "Bus")
                {
                    if (cmdType == "Drive")
                    {
                        bus.Drive(distance);
                    }
                    if (cmdType == "DriveEmpty")
                    {
                        bus.DriveEmpty(distance);
                    }
                    else if (cmdType == "Refuel")
                    {
                        bus.Refuel(distance);
                    }
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");

        }
    }
}
