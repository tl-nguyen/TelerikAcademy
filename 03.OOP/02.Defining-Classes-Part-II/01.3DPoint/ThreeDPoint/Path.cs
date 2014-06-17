using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDPoint
{
    public class Path
    {
        private readonly List<Point3D> points;

        public Path()
        {
            points = new List<Point3D>();
        }

        public List<Point3D> Points
        {
            get { return this.points; }
        }

        public void Add(Point3D point)
        {
            this.Points.Add(point);
        }

        public void Remove(Point3D point)
        {
            this.Points.Remove(point);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var point in this.Points)
            {
                result.Append(point.ToString() + "\n");
            }

            return result.ToString();
        }
    }
}
