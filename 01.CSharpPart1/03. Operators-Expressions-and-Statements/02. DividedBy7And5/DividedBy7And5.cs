using System;

class DividedBy7And5
{
    static void Main()
    {
        int number = 35;

        Console.WriteLine("number {0} can be divided by 5 and 7 at the same time : {1}", number, (number % 5 == 0 && number % 7 == 0));
    }
}

