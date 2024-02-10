using System;
using System.Collections.Generic;

namespace T03.ShoppingSpree
{
    public class Person
    {
        private string ime;
        private decimal kinti;
        private readonly List<Product> produkti;
        public ICollection<Product> Produkti { get; set; }

        public Person()
        {
            this.Produkti = new List<Product>();
        }

        public Person(string ime, decimal kinti)
        {
            this.Ime = ime;
            this.Kinti = kinti;
        }

        public string Ime
        {
            get
            {
                return this.ime;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.ime = value;
            }
        }

        public decimal Kinti
        {
            get
            {
                return this.kinti;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.kinti = value;
            }
        }

    }
}

