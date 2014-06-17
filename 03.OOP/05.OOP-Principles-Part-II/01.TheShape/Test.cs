using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TheShape
{
    class Test
    {
        public static void Main()
        {
            var shapes = new Shape[]
            {
                new Rectangle(10, 4),
                new Triangle(10, 4),
                new Circle(20)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Area of {0} = {1}", shape.GetType().Name, shape.CalculateSurface() );
            }
        }
    }
}
