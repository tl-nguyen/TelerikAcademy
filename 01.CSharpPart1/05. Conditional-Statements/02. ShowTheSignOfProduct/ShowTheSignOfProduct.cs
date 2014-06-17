using System;

class ShowTheSignOfProduct
{
    static void Main()
    {
        Console.Write("enter the first number: ");
        Double firstNum = realValueInput();
        Console.Write("enter the second number: ");
        Double secondNum = realValueInput();
        Console.Write("enter the third number: ");
        Double thirdNum = realValueInput();
        int minusSign = 0;
        
        if (firstNum < 0) minusSign++;
        if (secondNum < 0) minusSign++;
        if (thirdNum < 0) minusSign++;

        if (minusSign % 2 == 0)
        {
            Console.WriteLine("the sign of the product is +");
        }
        else
        {
            Console.WriteLine("the sign of the product is - ");
        }
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

