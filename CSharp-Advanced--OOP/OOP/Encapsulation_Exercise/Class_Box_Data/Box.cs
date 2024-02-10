using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        private const string ZeroOrNegativeArgumentException = "{0} cannot be zero or negative.";
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeArgumentException, nameof(this.Length)));
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeArgumentException, nameof(this.Width)));
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeArgumentException, nameof(this.Height)));
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * ((Width*Height) + (Length*Height) + (Length*Width));
        }

        public double LateralSurfaceArea()
        {
            return 2 * ((Length*Height) + (Width*Height));  
        }

        public double Volume()
        {
            return Height * Width * Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
               .AppendLine($"Surface Area - {this.SurfaceArea():f2}")
               .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
               .AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
