using System;
using System.Text;

class DecimalToHexadecimal
{
    static void Main()
    {
        int decNum = 56324;
        Console.WriteLine(DecToHex(decNum));
    }

    private static string DecToHex(int decNum)
    {
        String hexNum = "";

        for (; decNum > 0; decNum /= 16) hexNum = toHexDigitValue(decNum % 16) + hexNum;

        return hexNum;
    }

    private static char toHexDigitValue(int decValue)
    {
        char[] hexDigit = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        return hexDigit[decValue];
    }


}

