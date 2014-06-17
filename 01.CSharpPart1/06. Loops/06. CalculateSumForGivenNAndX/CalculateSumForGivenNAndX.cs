using System;

class CalculateSumForGivenNAndX
{
    static void Main()
    {
        Console.Write("Enter number N : ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter number X : ");
        int x = int.Parse(Console.ReadLine());
        Double sum = 1;
        Double fac = 1;

        for (int i = 1; i <= n; i++)
        {
            fac = fac * i;
            sum += fac / (x * i);
        }

        Console.WriteLine("S = " + sum);
    }
}

