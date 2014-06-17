using System;
using System.IO;

class MaxSumMatrix
{
    static void Main()
    {
        StreamReader matrixStream = new StreamReader(@"..\..\matrix.txt");
        StreamWriter maxSum = new StreamWriter(@"..\..\result.txt");
        
        using (matrixStream)
        using (maxSum)
        {
            int size = int.Parse(matrixStream.ReadLine());
            int[,] matrix = new int[size, size];
            int lineNum = 0;
            string line;
            
            while((line = matrixStream.ReadLine()) != null)
            {
                String[] block = line.Split(' ');
                for (int i = 0; i < size; i++)
                {
                    matrix[lineNum, i] = int.Parse(block[i]);
                }
                lineNum++;
            }

            Console.WriteLine(MaxSum(matrix));
            maxSum.WriteLine(MaxSum(matrix));
        }

    }

    private static int MaxSum(int[,] matrix)
    {
        int maxSum = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                int currentSum = matrix[i, j] + matrix[i, j+1] + matrix[i+1, j] + matrix[i+1, j+1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        return maxSum;
    }
}

