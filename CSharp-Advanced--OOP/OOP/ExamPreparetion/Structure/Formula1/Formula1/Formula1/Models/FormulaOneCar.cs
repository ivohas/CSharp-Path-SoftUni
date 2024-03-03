using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double enginedisplecment;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model {
            get => this.model;
           private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid car model: { model }.");
                }
                if (value.Length<3)
                {
                    throw new ArgumentException($"Invalid car model: {model}.");
                }
                this.model = value; 
            }
        
        }


        public int Horsepower {
            get => this.horsepower;
           private set {

                if (value>=900&&value<=1050)
                {
                    this.horsepower = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid car horsepower: { horsepower }.");
                }
            
            
            
            }
        
        
        }

        public double EngineDisplacement {
            get => this.enginedisplecment;
          private  set {
                if (value>1.5&&value<=2.0)
                {
                    this.enginedisplecment = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid car engine displacement: {  enginedisplecment }.");
                }
            
            }
        
        }

        public double RaceScoreCalculator(int laps)
        {
           double points= EngineDisplacement / Horsepower * laps;
            return points;
        }
    }
}
