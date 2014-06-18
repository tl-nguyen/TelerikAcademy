using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class RectangleCalculator : IFigureCalculate
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public RectangleCalculator(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("width and height can't be <= 0");
            }

            this.Width = width;
            this.Height = height;
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
