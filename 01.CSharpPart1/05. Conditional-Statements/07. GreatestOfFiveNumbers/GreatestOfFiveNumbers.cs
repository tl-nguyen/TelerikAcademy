using System;

class GreatestOfFiveNumbers
{
    static void Main()
    {
        Decimal[] numbers = new Decimal[] { 12, 10, 232, 4, 231 };
        Decimal greatest = numbers[0];

        Console.Write("Greatest of ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("[{0}] ", numbers[i]);
            if (numbers[i] > greatest)
            {
                greatest = numbers[i];
            }
        }
        Console.WriteLine("is : {0}",greatest);
    }
}

