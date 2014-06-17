using System;

class OddOrEven
{
    static void Main()
    {
        int number = 25;

        if(number%2 == 0)
            Console.WriteLine("the number {0} is even", number);
        else
            Console.WriteLine("the number {0} is odd", number);
    }
}

