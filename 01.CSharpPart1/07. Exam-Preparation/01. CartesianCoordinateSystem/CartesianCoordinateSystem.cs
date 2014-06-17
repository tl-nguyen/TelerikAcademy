using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        Decimal x = Decimal.Parse(Console.ReadLine());
        Decimal y = Decimal.Parse(Console.ReadLine());
        
        if (x == 0 && y == 0)
        {
            Console.WriteLine("0");
        }

        if (x == 0 && y != 0)
        {
            Console.WriteLine("5");
        }

        if (x != 0 && y == 0)
        {
            Console.WriteLine("6");
        }

        if (x > 0 && y > 0)
        {
            Console.WriteLine("1");
        }

        if (x < 0 && y > 0)
        {
            Console.WriteLine("2");
        }

        if (x < 0 && y < 0)
        {
            Console.WriteLine("3");
        }

        if (x > 0 && y < 0)
        {
            Console.WriteLine("4");
        }
    }
}

