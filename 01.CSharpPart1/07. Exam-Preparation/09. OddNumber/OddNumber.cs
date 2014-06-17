using System;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 1; i <= n; i++)
        {
            long number = long.Parse(Console.ReadLine());
            result ^= number;
        }
        Console.WriteLine(result);
    }
}

