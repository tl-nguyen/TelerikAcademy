using System;
using System.Globalization;

class DaysBetweenDates
{
    static void Main()
    {
        Console.Write("Enter first Date (d.MM.yyyy) = ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        Console.Write("Enter first Date (d.MM.yyyy) = ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Distance = " + Math.Abs((secondDate - firstDate).Days));
    }
}

