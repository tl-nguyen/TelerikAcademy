using System;

class BiggestOfThree
{
    static void Main()
    {
        Console.Write("enter the first number: ");
        int firstNum = IntegerValueInput();
        Console.Write("enter the second number: ");
        int secondNum = IntegerValueInput();
        Console.Write("enter the third number: ");
        int thirdNum = IntegerValueInput();

        int max = firstNum;

        if (secondNum > firstNum) max = secondNum;
        if (thirdNum > max) max = thirdNum;

        Console.WriteLine("the biggest of all = {0}", max);
    }

    static int IntegerValueInput()
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

