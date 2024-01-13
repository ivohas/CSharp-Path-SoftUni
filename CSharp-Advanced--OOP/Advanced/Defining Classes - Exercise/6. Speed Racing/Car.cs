using System;
using System.Collections.Generic;
using System.Text;

namespace _6._Speed_Racing
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double distanceTraveled;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumption = fuelConsumption;
        }
        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public double DistanceTraveled { get { return distanceTraveled; } set { distanceTraveled = value; } }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTraveled}";
        }

        public void Drive(double distance)
        {
            double fuelAmountNeeded = distance * this.FuelConsumption;

            if (fuelAmountNeeded > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.DistanceTraveled += distance;
                this.FuelAmount -= fuelAmountNeeded;
            }
        }
    }
}
