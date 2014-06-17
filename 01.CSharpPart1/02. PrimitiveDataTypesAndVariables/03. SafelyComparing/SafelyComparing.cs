using System;

class SafelyComparing
{
    static void Main()
    {
        float firstNumber;
        float secondNumber;
     
        Console.Write("Enter your first number : ");
        firstNumber = inputNumber();
        Console.Write("Enter your second number : ");
        secondNumber = inputNumber();

        Console.WriteLine("\nIs {0} equals to {1} : {2}", firstNumber, secondNumber, firstNumber == secondNumber );
    }

    static float inputNumber()
    {
        float result = 0.0f;
        Boolean isNumeric = false;

        while (!isNumeric)
        {
            isNumeric = float.TryParse(Console.ReadLine(), out result);
            if(!isNumeric)
            {
                Console.Write(" !!! not valid input\nPlease enter the number again : ");
            }
        }

        return result;
    }
}

