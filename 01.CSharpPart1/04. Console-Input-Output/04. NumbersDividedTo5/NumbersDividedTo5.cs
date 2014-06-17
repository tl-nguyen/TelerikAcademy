using System;

class NumbersDividedTo5
{
    static void Main()
    {
        int dividedToFiveCount = 0;
        Console.Write("Enter your first number: ");
        int firstNum = integerValueInput();
        Console.Write("Enter your second number: ");
        int secondNum = integerValueInput();

        if (firstNum % 5 == 0)
            dividedToFiveCount++;
        if (secondNum % 5 == 0)
            dividedToFiveCount++;

        dividedToFiveCount += Math.Abs(firstNum - secondNum) / 5;

        Console.WriteLine("The counts of number between {0} and {1}, which can be divided to 5 is = {2}", firstNum, secondNum, dividedToFiveCount);
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

