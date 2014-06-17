using System;

class IsPrimeNumber
{
    static void Main()
    {
        int number = 29;
        Boolean isPrime = true;

        for(int i = 2; i <= Math.Sqrt(number); i++ )
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine("The number {0} is prime : {1}", number, isPrime);
    }
}

