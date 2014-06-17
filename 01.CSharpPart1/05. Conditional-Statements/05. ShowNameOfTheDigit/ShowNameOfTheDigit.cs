using System;

class ShowNameOfTheDigit
{
    static void Main(string[] args)
    {
        Console.Write("Enter a digit : ");
        int digit = DigitInput();

        Console.Write("The digit name is : ");

        switch (digit)
        {
            case 0:
                Console.WriteLine("zero");
                break;
            case 1:
                Console.WriteLine("one");
                break;
            case 2:
                Console.WriteLine("two");
                break;
            case 3:
                Console.WriteLine("three");
                break;
            case 4:
                Console.WriteLine("four");
                break;
            case 5:
                Console.WriteLine("five");
                break;
            case 6:
                Console.WriteLine("six");
                break;
            case 7:
                Console.WriteLine("seven");
                break;
            case 8:
                Console.WriteLine("eight");
                break;
            case 9:
                Console.WriteLine("nine");
                break;
        }

        /*
        //Or without switch cases ;)

        String[] digitNames = new String[] { "zero", "one", "two", "three", "four"
                                             , "five", "six", "seven", "eight", "nine" };
        
        Console.WriteLine(digitNames[digit]); 
        */
    }

    static int DigitInput()
    {
        int number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = int.TryParse(Console.ReadLine(), out number);
            if (!isNumber || number > 9 || number < 0)
            {
                Console.Write("Please input a digit, Try again : ");
                isNumber = false;
            }
        }
        while (!isNumber);

        return number;
    }
}

