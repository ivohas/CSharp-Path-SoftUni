using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) : base(height, width)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateArea()
        {
            return base.Height * base.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (base.Height + base.Width);
        }

        public override string Draw()
        {
            return "Rectangle";
        }
    }
}
