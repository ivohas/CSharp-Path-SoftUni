using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private const decimal MIN_PRICE = 0;
        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                name = value;
            }
        }

        private string species;

        public string Species
        {
            get { return species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                species = value;
            }
        }

        private int size;

        public int Size { get; protected set; }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= MIN_PRICE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                price = value;
            }
        }
        public abstract void Eat();
    }
}
