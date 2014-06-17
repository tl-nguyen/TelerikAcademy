using System;

class BonusScores
{
    static void Main()
    {
        Console.Write("Please insert the score (1-9) :");
        int digit = DigitInput();

        switch(digit)
        {
            case 1:
            case 2:
            case 3:
                digit *= 10;
                break;
            case 4:
            case 5:
            case 6:
                digit *= 100;
                break;
            case 7:
            case 8:
            case 9:
                digit *= 1000;
                break;
        }

        Console.WriteLine("The final score is : {0}", digit);
    }

    static int DigitInput()
    {
        int number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = int.TryParse(Console.ReadLine(), out number);
            if (!isNumber || number > 9 || number < 1)
            {
                Console.Write("Please input a digit between 1 and 9, Try again : ");
                isNumber = false;
            }
        }
        while (!isNumber);

        return number;
    }
}

