using System;

class BitOfGivenPPosition
{
    static void Main(string[] args)
    {
        int number = 5;
        int p = 1;
        int mask = 1 << p;
        int numberAndMask = number & mask;
        numberAndMask = numberAndMask >> p;

        Console.WriteLine("The bit at position {0} of the number {1} is 1 : {2}", p, number, numberAndMask == 1);
    }
}

