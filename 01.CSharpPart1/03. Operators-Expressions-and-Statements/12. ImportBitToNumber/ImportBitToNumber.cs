using System;

class ImportBitToNumber
{
    static void Main()
    {
        int number = 3;
        int value = 1;
        int position = 2;
        int mask = 1 << position;

        if (value == 1)
        {
            number = number | mask;
        }

        if (value == 0)
        {
            mask = ~mask;
            number = number & mask;
        }

        Console.WriteLine("the new value of number with imported bit {0} ,with value {1} : {2} ", position, value, number);
    }
}

