using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
       
        private int destuction;

        public Weapon( int destructionLevel,double price)
        {
           
            DestructionLevel = destructionLevel;
            Price = price;
        }

        public double Price
        {
            get;
            private set;

        }

        public int DestructionLevel
        {
            get => this.destuction;
          private  set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                this.destuction = value;
            }


        }
    }
}
