using System;

class AreaOfATrapezoid
{
    static void Main(string[] args)
    {
        double a = 10;
        double b = 20;
        double h = 5;

        Console.WriteLine("The area of the trapezoid with a = {0}, b = {1}, h = {2} is {3}", a, b, h, (a+b)/2 * h);
    }
}

