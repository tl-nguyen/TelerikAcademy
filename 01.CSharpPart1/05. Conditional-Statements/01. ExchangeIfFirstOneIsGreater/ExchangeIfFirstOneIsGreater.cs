using System;

class ExchangeIfFirstOneIsGreater
{
    static void Main()
    {
        Console.Write("Enter the first number : ");
        int firstNum = integerValueInput();
        Console.Write("Enter the second number : ");
        int secondNum = integerValueInput();

        Console.WriteLine("Before check : ({0},{1})", firstNum, secondNum);
        if (firstNum > secondNum)
        {
            firstNum += secondNum;
            secondNum = firstNum - secondNum;
            firstNum = firstNum - secondNum;
        }
        Console.WriteLine("After check : ({0},{1})", firstNum, secondNum);
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

