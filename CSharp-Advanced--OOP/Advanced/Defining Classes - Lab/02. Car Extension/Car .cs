using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity;}
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption;}
            set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double consumption = distance * this.FuelConsumption;
            if (consumption <= this.FuelQuantity)
                this.FuelQuantity -= consumption;
            else
                Console.WriteLine("Not enough fuel to perform this trip!");
        }
        public string WhoAmI()
        {
            return
            $"Make: {this.Make}\r\n" +
            $"Model: {this.Model}\r\n" +
            $"Year: {this.Year}\r\n" +
            $"Fuel: {this.fuelQuantity:f2}L";
        }
    }
}
