﻿using System;

class PrintNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Enter the N number: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

