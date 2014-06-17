using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TheShape
{
    class Circle : Shape
    {
        public Circle(double r) : base(r, r)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Height;
        }
    }
}
