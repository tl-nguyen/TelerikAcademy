using System;

class IncreaseNumberByRowMatrix
{
    static void Main()
    {
        Console.Write("Enter the size of the matrix : ");
        ushort size = ushort.Parse(Console.ReadLine());

        if (size >= 20) Console.WriteLine("the input number has to be positive and smaller than 20");

        for (int row = 1; row <= size; row++)
        {
            int num = row;
            for (int col = 1; col <= size; col++, num++)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

    }
}

