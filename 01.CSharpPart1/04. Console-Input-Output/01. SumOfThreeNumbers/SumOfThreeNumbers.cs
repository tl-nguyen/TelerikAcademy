using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        int number1;
        int number2;
        int number3;

        Console.Write("enter the first number: ");
        number1 = integerValueInput();
        Console.Write("enter the second number: ");
        number2 = integerValueInput();
        Console.Write("enter the third number: ");
        number3 = integerValueInput();

        Console.WriteLine("{0} + {1} + {2} = {3}", number1, number2, number3, number1 + number2 + number3);
    }

    static int integerValueInput()
    {
        int number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = int.TryParse(Console.ReadLine(), out number);
            if(!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while(!isNumber);

        return number;
    }
}

 