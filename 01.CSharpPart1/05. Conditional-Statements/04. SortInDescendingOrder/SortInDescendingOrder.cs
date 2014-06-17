using System;

class SortInDescendingOrder
{
    static void Main()
    {
        Console.Write("enter the first number: ");
        Double firstNum = realValueInput();
        Console.Write("enter the second number: ");
        Double secondNum = realValueInput();
        Console.Write("enter the third number: ");
        Double thirdNum = realValueInput();

        Console.WriteLine("Before sorting : ({0},{1},{2})", firstNum, secondNum, thirdNum);

        if (firstNum < secondNum)
        {
            firstNum += secondNum;
            secondNum = firstNum - secondNum;
            firstNum = firstNum - secondNum;
        }
        if (secondNum < thirdNum)
        {
            secondNum += thirdNum;
            thirdNum = secondNum - thirdNum;
            secondNum = secondNum - thirdNum;

            if (firstNum < secondNum)
            {
                firstNum += secondNum;
                secondNum = firstNum - secondNum;
                firstNum = firstNum - secondNum;
            }
        }

        Console.WriteLine("After sorting : ({0},{1},{2})", firstNum, secondNum, thirdNum);
    }

    static Double realValueInput()
    {
        Double number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = Double.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while (!isNumber);

        return number;
    }
}

