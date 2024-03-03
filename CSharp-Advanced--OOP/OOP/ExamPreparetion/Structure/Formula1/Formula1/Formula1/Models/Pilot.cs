using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canrace=false;
        private IFormulaOneCar car;
        public Pilot(string fullname)
        {
            FullName = fullname;
        }
        public string FullName {
            get => this.fullName;
           private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid pilot name: {fullName}.");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {fullName}.");
                }
                this.fullName = value;
            }


        }

        public IFormulaOneCar Car {
            get => this.car;
           private set {
                if (value==null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            
            }
            
            }

        public int NumberOfWins {
            get;
            private set;        
        }

        public bool CanRace
        {

            get=>this.canrace;
            private set {
                this.canrace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {

            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
