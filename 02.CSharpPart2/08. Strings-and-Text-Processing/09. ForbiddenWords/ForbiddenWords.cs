using System;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    private static string MarkForbiddenWords(string text, string words)
    {
        words = words.Replace(" ", string.Empty);
        words = words.Replace(",", "|");

        return Regex.Replace(text, words, match => new String('*', match.Length));
    }

    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on"
                       + " .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP, CLR, Microsoft";

        Console.WriteLine(MarkForbiddenWords(text, words));
    }
}

