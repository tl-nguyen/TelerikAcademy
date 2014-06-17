using System;

class MaxSumOfElements
{
    static void Main()
    {
        int[,] matrix = 
        {
            {2, 3, 4, 3, 2},
            {3, 2, 11, 3, 4},
            {3, 3, 4, 51, 6},
            {6, 4, 2, 3, 4}
        };
        int maxSum = int.MinValue;
        int currentSum = maxSum;
        int[] maxSumIndex = { 0, 0 };

        if(matrix.GetLength(0) < 3 || matrix.GetLength(1) < 3)
        {
            Console.WriteLine("The dimesions must be >= 3x3");
            return;
        }

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
			{
                currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                             + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                             + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumIndex[0] = i;
                    maxSumIndex[1] = j;
                }            
			}
        }

        Console.WriteLine("The square 3x3 with the maximal sum = {0} is :", maxSum);

        for (int i = maxSumIndex[0]; i < maxSumIndex[0] + 3; i++)
        {
            for (int j = maxSumIndex[1]; j < maxSumIndex[1] + 3; j++)
            {
                Console.Write("{0} ", Convert.ToString(matrix[i, j]).PadRight((int)Math.Log10(matrix.Length) + 1, ' '));
            }
            Console.WriteLine();
        }
    }
}

