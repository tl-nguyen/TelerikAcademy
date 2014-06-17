using System;
using System.Collections.Generic;

class AddPositiveIntegers
{
    static void Main()
    {
        byte[] num1 = { 9, 1, 2, 3, 4, 2 };
        byte[] num2 = { 1, 3, 2, 1, 2, 8};

        PrintNumber(num1);
        PrintNumber(num2);
        PrintNumber(Add(num1, num2));
    }

    static void PrintNumber(byte[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--) Console.Write(arr[i]);

        Console.WriteLine();
    }

    static byte[] Add(byte[] num1, byte[] num2)
    {
        byte[] result = new byte[num1.Length >= num2.Length ? num1.Length + 1 : num2.Length + 1]; 

        int i = 0, carry = 0;

        for (; i < num1.Length; i++)
        {
            result[i] = (byte)(num1[i] + num2[i] + carry);

            carry = result[i] / 10;
            result[i] %= 10;
        }

        for (; i < num2.Length && carry != 0; i++)
        {
            result[i] = (byte)(num2[i] + carry);

            carry = result[i] / 10;
            result[i] %= 10;
        }

        for (; i < num2.Length; i++)
        {
            result[i] = num2[i];
        }

        if (carry != 0) result[i] = 1;
        else Array.Resize(ref result, result.Length - 1); 

        return result;
    }
}

