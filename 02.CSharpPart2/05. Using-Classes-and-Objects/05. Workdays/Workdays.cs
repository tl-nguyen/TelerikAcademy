using System;

class Workdays
{
    static void Main()
    {
        Console.WriteLine(GetWorkDays(new DateTime(2014, 1, 20)));
    }

    private static int GetWorkDays(DateTime dateTime)
    {
        int workDays = 0;
        int daysBetween = (int)(dateTime - DateTime.Today).TotalDays + 1;

        if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) daysBetween -= 2;
        else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) daysBetween--;

        workDays = daysBetween / 7 * 5 + daysBetween % 7;

        return workDays;
    }
}

