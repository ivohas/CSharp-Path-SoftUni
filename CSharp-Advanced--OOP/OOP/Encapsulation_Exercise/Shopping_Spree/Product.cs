using System;
namespace T03.ShoppingSpree
{
    public class Product
    {
        private string ime;
        private decimal cena;

        public Product(string ime, decimal cena)
        {
            this.Ime = ime;
            this.Cena = cena;
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

        public decimal Cena
        {
            get
            {
                return this.cena;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cena = value;
            }
        }
    }
}

