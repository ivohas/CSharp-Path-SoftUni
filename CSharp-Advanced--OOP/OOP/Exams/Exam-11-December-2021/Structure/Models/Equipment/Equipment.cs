using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

    }
}
