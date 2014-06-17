using System;

class GreaterOfTwo
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int firstNum = integerValueInput();
        Console.Write("Enter the second number: ");
        int secondNum = integerValueInput();

        Console.WriteLine("the greater of them is : {0}", (firstNum > secondNum) ? firstNum : secondNum);
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

