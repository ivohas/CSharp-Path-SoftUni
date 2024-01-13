using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string Make;
        private string Model;
        private int Year;
        private double FuelQuantity;
        private double FuelConsumption;

        public Car()
        {

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
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
            $"Fuel: {this.FuelQuantity:f2}L";
        }
    }
}
