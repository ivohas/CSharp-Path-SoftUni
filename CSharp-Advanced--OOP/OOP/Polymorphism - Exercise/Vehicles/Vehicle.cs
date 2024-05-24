using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public string Type { get; protected set; }
        public virtual void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (FuelQuantity >= neededFuel)
            {
                Console.WriteLine($"{this.Type} travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"{this.Type} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (this is Truck)
            {
                this.FuelQuantity += 0.95 * liters;
            }
            else if (this is Car)
            {
                this.FuelQuantity += liters;
            }
        }
    }
}
