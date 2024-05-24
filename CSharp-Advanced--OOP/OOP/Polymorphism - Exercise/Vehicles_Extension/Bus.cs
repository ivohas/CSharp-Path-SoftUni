using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) :
        base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumption + 1.4;
            double neededFuel = distance * currentFuelConsumption;
            if (FuelQuantity >= neededFuel)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }
    }
}
