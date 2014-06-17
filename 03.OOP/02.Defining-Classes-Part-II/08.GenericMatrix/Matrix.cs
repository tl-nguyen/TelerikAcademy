using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Matrix<T>
{
    private readonly T[,] matrix;
    public int Rows { get; private set; }
    public int Cols { get; private set; }

    public Matrix(int rows, int cols)
    {
        this.Rows = rows;
        this.Cols = cols;

        matrix = new T[this.Rows, this.Cols];
    }

    public T this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }

    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        if(m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new ArgumentException("the sizes of the matrixes have to be the same");
        }

        Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);

        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m2.Cols; j++)
            {
                result[i, j] = (dynamic)m1[i, j] + m2[i, j];
            }
        }

        return result;
    }

    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new ArgumentException("the sizes of the matrixes have to be the same");
        }

        Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);

        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m2.Cols; j++)
            {
                result[i, j] = (dynamic)m1[i, j] - m2[i, j];
            }
        }

        return result;
    }

    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1.Cols != m2.Rows)
            throw new ArgumentException("The sizes of the matrixes have to be the same and cols size should be equal to rows size!");

        Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);

        for (int i = 0; i < result.Rows; i++)
            for (int j = 0; j < result.Cols; j++)
                for (int k = 0; k < m1.Cols; k++)
                    result[i, j] += (dynamic)m1[i, k] * m2[k, j];

        return result;
    }

    public static bool operator true(Matrix<T> m)
    {
        foreach (var item in m.matrix)
        {
            if ((dynamic)item != 0) return true;
        }

        return false;
    }

    public static bool operator false(Matrix<T> m)
    {
        foreach (var item in m.matrix)
        {
            if ((dynamic)item != 0) return false;
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                output.Append(this.matrix[i, j] + " ");
            }
            output.Append("\n");
        }

        return output.ToString();
    }
}

