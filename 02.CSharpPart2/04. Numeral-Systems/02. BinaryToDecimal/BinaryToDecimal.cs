using System;

class BinaryToDecimal
{
    static void Main()
    {
        int binNum = 110011;

        Console.WriteLine(BinToDec(binNum, 0, 0));
    }

    private static int BinToDec(int binNum, int decNum, int step)
    {
        if(binNum == 0) return decNum;
        decNum += (int)((binNum % 10) * Math.Pow(2, step));
        return BinToDec(binNum / 10, decNum, ++step);
    }
}

