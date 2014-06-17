using System;
using System.Text.RegularExpressions;

class ToUpperCaseTags
{
    private static string ToUpperCaseByTags(string text)
    {
        return Regex.Replace(text, "<upcase>(.*?)</upcase>", match => match.Groups[1].Value.ToUpper());
    }

    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        Console.WriteLine(ToUpperCaseByTags(text));
    }
}

