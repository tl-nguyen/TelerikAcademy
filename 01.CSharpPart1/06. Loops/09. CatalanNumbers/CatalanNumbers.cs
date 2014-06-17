using System;

class CatalanNumbers
{
    static void Main()
    {
        Double n = 3;
        Double number = 1;

        for (int k = 2; k <= n; k++)
        {
            number *= (n + k) / k;
        }

        Console.WriteLine("the number {0} of Catalan numbers is {1}", n, number);
    }
}

