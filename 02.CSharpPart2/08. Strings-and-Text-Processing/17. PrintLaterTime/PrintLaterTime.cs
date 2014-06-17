using System;
using System.Globalization;

class PrintLaterTime
{
    static void Main()
    {
        DateTime date = DateTime.ParseExact("17.01.2014 23:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        date = date.AddHours(6.5);

        Console.WriteLine("{0} {1}", date, date.ToString("dddd", new CultureInfo("bg-BG")));
    }
}

