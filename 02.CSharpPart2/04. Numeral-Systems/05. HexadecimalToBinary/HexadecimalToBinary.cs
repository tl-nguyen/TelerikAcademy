using System;

class HexadecimalToBinary
{
    static void Main()
    {
        string hexNum = "DFD";
        Console.WriteLine(HexToBin(hexNum));
    }

    private static string HexToBin(string hexNum)
    {
        string binNum = "";
        for (int i = hexNum.Length - 1; i >= 0 ; i--)
        {
            binNum = ConvertToBin(hexNum[i]) + binNum;
        }
        
        return binNum;
    }

    private static string ConvertToBin(char digit)
    {
        string[] binVal = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        char[] hexVal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        int i = 0;

        for (; i < hexVal.Length; i++)
        {
            if(hexVal[i].Equals(digit)) break;
        }

        return binVal[i];
    }
}

