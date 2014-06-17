using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("a = ");
        int a = integerValueInput();
        Console.Write("b = ");
        int b = integerValueInput();
        Console.Write("c = ");
        int c = integerValueInput();

        int d = b * b - 4 * a * c;

        Console.WriteLine("first root = {0:0.00}",(double)(-b + Math.Sqrt(d)) / (2 * a));
        Console.WriteLine("second root = {0:0.00}",(double)(-b - Math.Sqrt(d)) / (2 * a));
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

