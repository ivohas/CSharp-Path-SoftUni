using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) :
    base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (FuelQuantity >= neededFuel)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }
    }
}
