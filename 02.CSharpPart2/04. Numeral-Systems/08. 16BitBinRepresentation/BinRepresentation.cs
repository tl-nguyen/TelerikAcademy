using System;

class BinRepresentation
{
    static void Main()
    {
        short num = 123;
        Console.WriteLine(ToBinary(num));
    }
    static string ToBinary(short num)
    {
        string binValue = String.Empty;
        for (int i = 0; i < 16; i++) binValue = (num >> i & 1) + binValue;
        return binValue;
    }
}

