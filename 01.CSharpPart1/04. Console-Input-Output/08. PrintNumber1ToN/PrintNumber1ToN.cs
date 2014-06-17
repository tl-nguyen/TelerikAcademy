using System;

class PrintNumber1ToN
{
    static void Main()
    {
        Console.Write("Enter the number N : ");
        int n = integerValueInput();

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
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

