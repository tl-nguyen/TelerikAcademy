using System;

class LongestSequence
{
    static void Main()
    {
        String[,] matrix = 
        {
            {"s", "s", "s", "s"},
            {"hd", "ha", "sd", "a"},
            {"had", "sf", "h", "s"}
        };

        int maxSequenceCount = 1;
        String maxSequenceString = matrix[0, 0];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                //Check if we've already worked with this sequence before
                if ((j > 0 && i > 0 && (matrix[i, j].Equals(matrix[i - 1, j - 1])
                                       || matrix[i, j].Equals(matrix[i, j - 1])
                                       || matrix[i, j].Equals(matrix[i - 1, j])))
                    || (j < matrix.GetLength(1) - 1 && i > 0 && matrix[i, j].Equals(matrix[i - 1, j + 1])))
                {
                    continue;
                }

                int col = j + 1;
                int row = i + 1;
                int sequenceCount = 1;

                //Check sequence on the same column
                while (col < matrix.GetLength(1) && matrix[i, j].Equals(matrix[i, col])) 
                {
                    col++;
                    sequenceCount++;
                }
                if (sequenceCount >= maxSequenceCount)
                {
                    maxSequenceCount = sequenceCount;
                    maxSequenceString = matrix[i, j];
                }

                //Check sequence on the same row
                sequenceCount = 1;
                while (row < matrix.GetLength(0) && matrix[i, j].Equals(matrix[row, j]))
                {
                    row++;
                    sequenceCount++;
                }
                if (sequenceCount >= maxSequenceCount)
                {
                    maxSequenceCount = sequenceCount;
                    maxSequenceString = matrix[i, j];
                }

                //Check sequence on right diagonal
                sequenceCount = 1;
                col = j + 1;
                row = i + 1;
                while (row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[i, j].Equals(matrix[row, col]))
                {
                    row++;
                    col++;
                    sequenceCount++;
                }
                if (sequenceCount >= maxSequenceCount)
                {
                    maxSequenceCount = sequenceCount;
                    maxSequenceString = matrix[i, j];
                }

                //Check sequence on left diagonal
                sequenceCount = 1;
                col = j - 1;
                row = i + 1;
                while (row < matrix.GetLength(0) && col >= 0 && matrix[i, j].Equals(matrix[row, col]))
                {
                    row++;
                    col--;
                    sequenceCount++;
                }
                if (sequenceCount >= maxSequenceCount)
                {
                    maxSequenceCount = sequenceCount;
                    maxSequenceString = matrix[i, j];
                }
            }
        }

        for (int i = 0; i < maxSequenceCount; i++)
        {
            Console.Write(i == maxSequenceCount - 1 ? maxSequenceString + "\n" : maxSequenceString + ", ");
        }
    }
}

