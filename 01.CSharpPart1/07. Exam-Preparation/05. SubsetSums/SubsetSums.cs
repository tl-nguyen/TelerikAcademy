using System;

class SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int sumCounts = 0;
        long[] numbers = new long[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        int maxCombinations = (int)Math.Pow(2, (double)n) - 1;

        for (int i = 1; i <= maxCombinations; i++)
        {
            long sum = 0;
            for (int j = 0; j < n; j++)
            {
                if ((i >> j & 1) == 1) sum += numbers[j];
            }
            if (sum == s) sumCounts++;
        }

        Console.WriteLine(sumCounts);
    }   
}

