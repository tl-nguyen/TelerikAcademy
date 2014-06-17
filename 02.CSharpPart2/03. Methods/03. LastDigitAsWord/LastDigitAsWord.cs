using System;

class LastDigitAsWord
{
    static void Main()
    {
        Console.Write("enter your number : ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(LastDigit(num));
    }

    static public String LastDigit(int num)
    {
        String[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digits[num % 10];
    }
}

