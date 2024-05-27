using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public Shape(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        private double height;

        public double Height
        {
            get { return height; }
            protected set { height = value; }
        }

        private double width;

        public double Width
        {
            get { return width; }
            protected set { width = value; }
        }
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public virtual string Draw()
        {
            return "";
        }
    }
}
