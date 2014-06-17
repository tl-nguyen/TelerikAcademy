using System;
using System.Text;

class Maximum20Characters
{
    private static string ConvertTo20Chars(string text)
    {
        StringBuilder result = new StringBuilder("");

        for (int i = 0; i < 20; i++)
        {
            if (i < text.Length) result.Append(text[i]);
            else result.Append('*');
        }

        return result.ToString();
    }

    static void Main()
    {
        string text = Console.ReadLine();
        Console.WriteLine(ConvertTo20Chars(text));
    }
}

