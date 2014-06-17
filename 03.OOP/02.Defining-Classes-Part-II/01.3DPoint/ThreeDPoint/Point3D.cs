using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDPoint
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        private static readonly Point3D startPoint = new Point3D(0, 0 , 0);

        public static Point3D StartPoint
        {
            get
            {
                return startPoint;  
            }
        }

        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return String.Format("({0},{1},{2})", this.X, this.Y, this.Z);
        }
    }
}
