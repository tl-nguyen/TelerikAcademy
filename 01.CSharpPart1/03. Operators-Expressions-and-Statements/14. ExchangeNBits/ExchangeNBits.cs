using System;

class ExchangeNBits
{
    static int result;

    static void Main()
    {
        int number = 7;
        int p = 0;
        int q = 10;
        int k = 3;

        if(k > (q-p) || p > q)
        {
            Console.WriteLine("wrong input!, q has to be greater than p , and k has to be <= than ( q - p )");
            return;
        }

        result = number;

        for (int i = 0; i < k; i++, p++, q++)
        {
            exchangePositions(p, q);
        }
        
        Console.WriteLine("the number {0} after exchange bits = {1}", number, result);
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

