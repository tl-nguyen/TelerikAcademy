using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    public static void Main()
    {
        var m1 = new Matrix<int>(6, 6);
        var m2 = new Matrix<int>(6, 6);

        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                m1[i, j] = i + j;
                m2[i, j] = i - j;
            }
        }
        Console.WriteLine("Matrix1 : \n{0}", m1);

        Console.WriteLine("Matrix2 : \n{0}", m2);

        Console.WriteLine("Matrix1 + Matrix2: \n{0}", m1 + m2);

        Console.WriteLine("Matrix1 - Matrix2: \n{0}", m1 - m2);

        Console.WriteLine("Matrix1 * Matrix2: \n{0}", m1 * m2);

        if (m1) Console.WriteLine("Matrix 1 : elements are not zeros");
        else Console.WriteLine("elements are zeros");

        var zerosElementsMatrix = new Matrix<double>(4, 4);
        Console.WriteLine("zero-elements Matrix: \n{0}", zerosElementsMatrix);

        if (zerosElementsMatrix) Console.WriteLine("Matrix 1 : elements are not zeros");
        else Console.WriteLine("elements are zeros");

    }
}

