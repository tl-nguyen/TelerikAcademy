using System;

class DecimalToBinary
{
    static void Main()
    {
        int decNum = 52;

        Console.WriteLine(DecToBin(decNum, 0, 1));
    }

    private static int DecToBin(int num, int binNum, int step)
    {
        if (num == 0) return binNum;
        binNum += ((num % 2) * step);
        return DecToBin((num / 2), binNum, step * 10);
    }
}

