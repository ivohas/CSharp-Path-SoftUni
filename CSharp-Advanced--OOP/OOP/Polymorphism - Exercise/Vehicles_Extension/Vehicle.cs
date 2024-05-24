using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value <= TankCapacity)
                {
                    fuelQuantity = value;

                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }

        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; set; }
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

        public virtual void DriveEmpty(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
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
        public virtual void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this is Truck)
                {
                    if (this.FuelQuantity + 0.95 * liters < TankCapacity)
                    {
                        this.FuelQuantity += 0.95 * liters;
                    }
                    else Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    if (this.FuelQuantity + liters < TankCapacity)
                    {
                        this.FuelQuantity += liters;
                    }
                    else Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
            else Console.WriteLine("Fuel must be a positive number");
        }
    }
}
