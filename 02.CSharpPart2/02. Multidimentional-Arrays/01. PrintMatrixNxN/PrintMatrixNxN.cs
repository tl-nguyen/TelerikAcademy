using System;

class PrintMatrixNxN
{
    static void Main()
    {
        Console.Write("Matrix size = ");
        int n = int.Parse(Console.ReadLine());

        PrintMatrix(ASolution(n));
        PrintMatrix(BSolution(n)); 
        PrintMatrix(CSolution(n)); 
        //PrintMatrix(DSolution(n));
    }

    private static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", (matrix[i, j].ToString()).PadRight((int)Math.Log10(matrix.Length) + 1, ' '));
            }
            Console.WriteLine();
        }
    }

    private static int[,] ASolution(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 1;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, j] = counter;
                counter++;
            }
        }

        return matrix;
    }

    private static int[,] BSolution(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 1;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int i = (j % 2 == 0 ? 0 : size);
            if (i == 0)
            {
                for (; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
            else
            {
                i--;
                for (; i >= 0; i--)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
        }

        return matrix;
    }

    private static int[,] CSolution(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 1;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++, counter++)
            {
                matrix[size - i + j - 1, j] = counter;
            }
        }
            

        for (int i = size - 2; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--, counter++)
            {
                matrix[i - j, size - j - 1] = counter;
            }
        }

        return matrix;
    }

    private static int[,] DSolution(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 1;

        return matrix;
    }
  
}

