using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 0; i < this.Height; ++i)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }

        public void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < width; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
