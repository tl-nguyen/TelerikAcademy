using System;

class TrailingZerosOfNFactorial
{
    static void Main()
    {
        int n = 50000;
        int trailingZeros = 0;

        for (int i = 5; i <= n; i *= 5)
        {
            trailingZeros += n / i;
        }
        
        Console.WriteLine("Trailing Zero of {0}! are {1}", n, trailingZeros);
    }
}

