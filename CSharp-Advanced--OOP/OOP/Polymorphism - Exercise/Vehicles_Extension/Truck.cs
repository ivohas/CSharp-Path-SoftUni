using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) :
    base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
        }
        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (FuelQuantity >= neededFuel)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }
        }

    }
}
