using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius, double height, double width) : base(height, width)
        {
            this.Radius = radius;
            this.Height = height;
            this.Width = width;
        }

        private double radius;

        public double Radius
        {
            get { return radius; }
            private set { radius = value; }
        }
        public override double CalculateArea()
        {
            return  Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius ;
        }

        public override string Draw()
        {
            return "Circle";
        }
    }
}
