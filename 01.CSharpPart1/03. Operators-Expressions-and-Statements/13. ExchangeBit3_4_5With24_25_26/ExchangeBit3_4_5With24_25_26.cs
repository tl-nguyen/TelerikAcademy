using System;

class ExchangeBit3_4_5With24_25_26
{
    static int result;

    static void Main()
    {
        int number = 24;
        result = number;

        exchangePositions(3, 24);
        exchangePositions(4, 24);
        exchangePositions(5, 24);

        Console.WriteLine("the number {0} after exchange bits 3,4,5 with bits 24,25,26 = {1}", number, result);
    }

    static void exchangePositions(int p1, int p2)
    {
        int mask1 = 1 << p1;
        int mask2 = 1 << p2;

        int p1Value = (result & mask1) >> p1;
        int p2Value = (result & mask2) >> p2;

        putBitInPosition(p1Value, p2);
        putBitInPosition(p2Value, p1);
    }

    static void putBitInPosition(int value, int position)
    {
        int mask = 1 << position;

        if (value == 1)
        {
            result = result | mask;
        }
        else if (value == 0)
        {
            mask = ~mask;
            result = result & mask;
        }
    }
}

