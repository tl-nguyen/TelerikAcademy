using System;

class PrintNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15}\n{0,15:X}\n{0,15:P}\n{0,15:E}", number);
    }
}

