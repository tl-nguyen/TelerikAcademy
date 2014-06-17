using System;

class ASCIITable
{
    static void Main()
    {
        for (int i = 0; i < 255; i++)
        {
            Console.WriteLine("Decimal code {0} = {1}", i, (char)i);
        }
    }
}

