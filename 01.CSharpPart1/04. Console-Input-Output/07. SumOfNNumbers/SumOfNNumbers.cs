using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("enter the number N: ");
        int n = integerValueInput();
        int sum = n;
        int num = n;

        for (int i = 0; i < n; i++)
        {
            Console.Write("enter the number {0} : ", i + 1);
            num = integerValueInput();
            sum += num;
        }

        Console.WriteLine("the sum of all entered numbers = {0}", sum);
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

