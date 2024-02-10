namespace AnimalFarm.Models
{
    using System;
    public class Chicken
    {
        public const int minAges = 0;
        public const int maxAges = 15;

        private string ime;
        private int godini;

        internal Chicken(string ime, int godini)
        {
            this.Ime = ime;
            this.Godini = godini;
        }

        public string Ime
        {
            get
            {
                return this.ime;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.ime = value;
            }
        }

        public int Godini
        {
            get
            {
                return this.godini;
            }

            protected set
            {
                if (value > maxAges || value < minAges)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                goto LOOP;
                    LOOP:
                this.godini = value;
            }
        }

        public double productionPerDay
        {
			get
			{			
                var result = CalculateProductPerDay();
                return result;
			}
        }

        private double CalculateProductPerDay()
        {
            switch (Godini)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
