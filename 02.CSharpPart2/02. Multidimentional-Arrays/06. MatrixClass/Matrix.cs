using System;
using System.Text;

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
    }

    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    public int GetRowsLength()
    {
        return matrix.GetLength(0);
    }

    public int GetColsLength()
    {
        return matrix.GetLength(1);
    }

    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrixResult = new Matrix(matrix1.GetRowsLength(), matrix1.GetColsLength());

        for (int i = 0; i < matrixResult.GetRowsLength(); i++)
            for (int j = 0; j < matrixResult.GetColsLength(); j++)
                matrixResult[i, j] = matrix1[i, j] + matrix2[i, j];

        return matrixResult;
    }

    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrixResult = new Matrix(matrix1.GetRowsLength(), matrix1.GetColsLength());

        for (int i = 0; i < matrixResult.GetRowsLength(); i++)
            for (int j = 0; j < matrixResult.GetColsLength(); j++)
                matrixResult[i, j] = matrix1[i, j] - matrix2[i, j];

        return matrixResult;
    }

    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrixResult = new Matrix(matrix1.GetRowsLength(), matrix2.GetColsLength());

        for (int i = 0; i < matrixResult.GetRowsLength(); i++)
            for (int j = 0; j < matrixResult.GetColsLength(); j++)
                for (int k = 0; k < matrix1.GetColsLength(); k++)
                    matrixResult[i, j] += matrix1[i, k] * matrix2[k, j];

        return matrixResult;
    }

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();

        for (int i = 0; i < this.GetRowsLength(); i++)
            for (int j = 0; j < this.GetColsLength(); j++)
                s.Append(((this.matrix[i, j].ToString()).PadRight(5, ' ') + (j != this.GetColsLength() - 1 ? " " : "\n")));

        return s.ToString();
    }

    static void Main()
    {
        Matrix matrix1 = new Matrix(5, 5);
        Matrix matrix2 = new Matrix(5, 5);

        Random rand = new Random();
        for (int i = 0; i < matrix1.GetRowsLength(); i++)
        {
            for (int j = 0; j < matrix1.GetColsLength(); j++)
            {
                matrix1[i, j] = rand.Next(100);
                matrix2[i, j] = rand.Next(100);
            }
        }

        Console.WriteLine("matrix1");
        Console.WriteLine(matrix1);

        Console.WriteLine("matrix2");
        Console.WriteLine(matrix2);

        Console.WriteLine("Add");
        Console.WriteLine(matrix1 + matrix2);

        Console.WriteLine("Subtract");
        Console.WriteLine(matrix1 - matrix2);

        Console.WriteLine("Multiply");
        Console.WriteLine(matrix1 * matrix2);
    }
    
}

