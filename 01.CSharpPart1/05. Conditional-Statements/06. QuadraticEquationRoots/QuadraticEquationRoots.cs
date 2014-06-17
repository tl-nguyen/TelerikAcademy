using System;

class QuadraticEquationRoots
{
    static void Main()
    {
        Console.Write("a = ");
        int a = integerValueInput();
        Console.Write("b = ");
        int b = integerValueInput();
        Console.Write("c = ");
        int c = integerValueInput();

        Double firstRoot;
        Double secondRoot;

        int d = b * b - 4 * a * c;
        firstRoot = (Double)(-b + Math.Sqrt(d)) / (2 * a);
        secondRoot = (Double)(-b - Math.Sqrt(d)) / (2 * a);

        Console.WriteLine("Real roots are : ");
        if (!Double.IsNaN(firstRoot)) Console.WriteLine("{0:0.000}", firstRoot);
        if (!Double.IsNaN(secondRoot)) Console.WriteLine("{0:0.000}", secondRoot);
        if (Double.IsNaN(firstRoot) && Double.IsNaN(secondRoot)) Console.WriteLine("no real roots");
    }

    static int integerValueInput()
    {
        int number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = int.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while (!isNumber);

        return number;
    }
}

