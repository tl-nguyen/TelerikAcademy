using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
            this.Type = Type.circle;
            this.Calculator = new CircleCalculator(radius);
        }
    }
}
