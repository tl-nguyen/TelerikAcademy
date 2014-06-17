using System;


class BinaryToHexademical
{
    static void Main()
    {
        String binNum = "11111101";
        Console.WriteLine(BinToHex(binNum));
    }

    static string BinToHex(string binNum)
    {
        if (binNum.Length % 4 != 0) return BinToHex(new String('0', 4 - binNum.Length % 4) + binNum);

        string hexNum = String.Empty;

        for (int i = binNum.Length - 1; i >= 0; i -= 4)
        {
            int nibble = 0;

            for (int j = 0, power = 1; j < 4; j++, power *= 2)
                nibble += ToNumber(binNum, i - j) * power;

            hexNum = ToHexDigit(nibble) + hexNum;
        }

        return hexNum;
    }

    static int ToNumber(string binNum, int i)
    {
        return binNum[i] - '0';
    }

    static char ToHexDigit(int i)
    {
        if (i >= 10) return (char)('A' + i - 10);
        else return (char)('0' + i);
    }
}

