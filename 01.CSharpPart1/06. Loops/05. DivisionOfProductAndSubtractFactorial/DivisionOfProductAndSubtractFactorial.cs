using System;

class DivisionOfProductAndSubtractFactorial
{
    static void Main()
    {
        int k = 10, n = 8;
        int factorial = 1;

        if (n <= 1 || k <= n)
        {
            Console.WriteLine(" the condition of K and N must be (1 < N < K )");
        }

        for (int i = 0; i < n; i++)
        {
            factorial *= k - i;
        }

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("{0}!*{1}!/({0}-{1})! = {2}", k, n, factorial);
    }
}

