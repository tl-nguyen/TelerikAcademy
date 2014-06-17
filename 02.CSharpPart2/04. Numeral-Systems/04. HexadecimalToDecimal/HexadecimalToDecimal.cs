using System;
using System.Text;

class HexadecimalToDecimal
{
    static void Main()
    {
        string hexNum = "C";
        Console.WriteLine(HexToDec(hexNum));
    }

    private static int HexToDec(string hexNum)
    {
        int decNum = 0;
        for (int i = hexNum.Length - 1, step = 0; i >= 0; i--, step++)
        {
            decNum += (int)(HexDigitToDec(hexNum[i]) * Math.Pow(16, step));
        }
        return decNum;
    }

    private static int HexDigitToDec(char hexValue)
    {
        char[] hexDigit = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 0; i < hexDigit.Length; i++)
        {
            if (hexDigit[i].Equals(hexValue)) return i;
        }
        return 0;
    }
}

