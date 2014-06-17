using System;

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine(GetAreaWithAltitude(12, 24));
        Console.WriteLine(GetAreaWithSides(23, 2, 4));
        Console.WriteLine(GetAreaWithAngle(23, 4, 90));
    }

    static double GetAreaWithAltitude(double a, double h)
    {
        return (a * h) / 2;
    }

    static double GetAreaWithSides(double a, double b, double c)
    {
        double p = (a + b + c) / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }


    static double GetAreaWithAngle(double a, double b, double alpha)
    {
        return (a * b * Math.Sin(Math.PI * alpha / 180)) / 2;
    }
}

