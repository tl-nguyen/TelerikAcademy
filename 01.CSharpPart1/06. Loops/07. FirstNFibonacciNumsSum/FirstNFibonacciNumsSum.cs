using System;

class FirstNFibonacciNumsSum
{
    static void Main()
    {
        Console.Write("Enter number N : ");
        int n = int.Parse(Console.ReadLine());
        int prev = 0;
        int curr = 1;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += prev;
            curr = prev + curr;
            prev = curr - prev;
        }

        Console.WriteLine("Sum = " + sum);
    }
}

