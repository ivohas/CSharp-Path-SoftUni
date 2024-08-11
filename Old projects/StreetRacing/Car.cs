using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    internal class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
                      
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}")
                .AppendLine($"Model: {Model}").
                AppendLine($"License Plate: {LicensePlate}")
                .AppendLine($"Horse Power: {HorsePower}")
                .Append($"Weight: {Weight}");

            return sb.ToString();
        }
    }
}
