using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Type = Type.rectangle;
            this.Calculator = new RectangleCalculator(width, height);
        }
    }
}
