using System;

class FindingTheBit3
{
    static void Main()
    {
        int number = 9;
        int mask = 1 << 3;
        int numberAndMask = number & mask;
        int result = numberAndMask >> 3;

        Console.WriteLine("bit 3 of the number {0} is {1}", number, result);
    }
}

