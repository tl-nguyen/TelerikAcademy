using System;
using System.Text;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = n * 2;
        int height = n + 1;
        char border = '*';
        char empty = '.';
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < height; i++)
        {
            if(i == 0 )
            {
                result.Append(empty,n);
                result.Append(border, n);
                result.Append('\n');
                continue;
            }

            if(i == height - 1)
            {
                result.Append(border, width);
                continue;
            }

            result.Append(empty, n - i);
            result.Append(border);
            result.Append(empty, n - 2 + i);
            result.Append(border);
            result.Append('\n');
        }

        Console.WriteLine(result);
    }
}

