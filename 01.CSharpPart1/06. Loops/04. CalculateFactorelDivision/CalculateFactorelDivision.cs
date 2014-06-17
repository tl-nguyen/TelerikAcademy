using System;

class CalculateFactorelDivision
{
    static void Main(string[] args)
    {
        int n = 10, k = 8;
        int factorial = 1;
            
        if( k <= 1 || n <= k)
        {
            Console.WriteLine(" the condition of K and N must be (1 < K < N )");
        }

        for (int i = 0; i < n - k; i++)
        {
            factorial *= n - i;
        }

        Console.WriteLine("{0}!/{1}! = {2}", n, k, factorial);
    }
}

