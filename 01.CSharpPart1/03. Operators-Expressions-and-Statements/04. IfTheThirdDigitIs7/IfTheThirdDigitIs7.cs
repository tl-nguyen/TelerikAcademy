using System;

class IfTheThirdDigitIs7
{
    static void Main(string[] args)
    {
        int number = 43423732;

        Console.WriteLine("The third digit of the number {0} is 7 : {1}", number ,((number / 100) % 10 == 7));
    }
}
