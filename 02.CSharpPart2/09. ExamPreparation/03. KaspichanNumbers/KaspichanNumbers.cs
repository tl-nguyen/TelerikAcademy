using System;
using System.Collections.Generic;

class KaspichanNumbers
{
    static void Main(string[] args)
    {
        ulong input = ulong.Parse(Console.ReadLine());
        var numbers = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++)
        {
            numbers.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'z'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                numbers.Add(i.ToString() + j.ToString());
            }
        }

        string result = "";

        if (input == 0) Console.WriteLine("A");

        while (input > 0)
        {
            result = numbers[(int)input % 256].ToString() + result;
            input = input / 256;
        }

        Console.WriteLine(result);
    }
}

