using System;

class ValuesExchange
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("Before exchange : a = {0} ; b = {1}", a, b);
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("After exchange : a = {0} ; b = {1}", a, b);
    }
}

