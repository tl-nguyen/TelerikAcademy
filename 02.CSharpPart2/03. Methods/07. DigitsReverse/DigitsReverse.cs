using System;

class DigitsReverse
{
    static void Main()
    {
        int num = 26501;
        Console.WriteLine(ReverseDigits(num, 0));
    }

    static public int ReverseDigits(int num, int result)
    {
        if (num == 0) return result;
        return ReverseDigits(num / 10, (result * 10) + num % 10);
    }
}

