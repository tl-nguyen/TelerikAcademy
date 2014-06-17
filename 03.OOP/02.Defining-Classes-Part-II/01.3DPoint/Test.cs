using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPoint;


class Test
{
    public static void Main()
    {
        Point3D point1 = new Point3D(2, 3, 4);
        Point3D point2 = new Point3D(3, 4, 5);
        Point3D point3 = new Point3D(4, 5, 6);

        //test distance method
        Console.WriteLine("Distance between Point 1 and Point 2 = {0:0.00}", Point3DCalculator.getDistance(point1, point2));

        Path points = new Path();
        points.Add(point1);
        points.Add(point2);
        points.Add(point3);

        //test Save And Load to File
        PathStorage.Save(points, @"../../test.txt");
        Console.WriteLine(PathStorage.Load(@"../../test.txt"));
    }
}

