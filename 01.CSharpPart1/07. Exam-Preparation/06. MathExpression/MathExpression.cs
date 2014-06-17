using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        Console.WriteLine("{0:0.000000}",((n*n + (1 / (m * p)) + 1337) / (n - (decimal)128.523123123 * p)) + (decimal)Math.Sin((int)m % 180));
    }
}

