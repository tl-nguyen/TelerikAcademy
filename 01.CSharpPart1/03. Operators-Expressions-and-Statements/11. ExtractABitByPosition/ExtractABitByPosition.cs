using System;

class ExtractABitByPosition
{
    static void Main()
    {
        int number = 5;
        int bitPosition = 2;
        int mask = 1 << bitPosition;
        int numberAndMask = number & mask;
        int bit = numberAndMask >> bitPosition;
        

        Console.WriteLine("The bit {0} of number {1} is : {2}", bitPosition, number, bit);
    }
}

