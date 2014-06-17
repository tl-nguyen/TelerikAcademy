using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter the size of the matrix : ");
        ushort size = ushort.Parse(Console.ReadLine());
        int depth = 0;

        if (size >= 20) Console.WriteLine("the size has to be positive and smaller than 20");

    }
}

