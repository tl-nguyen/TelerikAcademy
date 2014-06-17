using System;
using System.Text;
class ForestRoad
{
    static void Main()
    {
        StringBuilder output = new StringBuilder();
        int n = int.Parse(Console.ReadLine());
        char tree = '.';
        char road = '*';

        for (int i = 0; i < n; i++)
        {
            output.Append(tree, i);
            output.Append(road);
            output.Append(tree, n - i - 1);
            output.Append('\n');
        }

        for (int i = 0; i < n - 1; i++ )
        {
            output.Append(tree, n - 2 - i);
            output.Append(road);
            output.Append(tree, i + 1);
            output.Append('\n');
        }

        Console.WriteLine(output);
    }
}

