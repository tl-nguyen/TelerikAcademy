using System;
using System.Text.RegularExpressions;

class ReplaceIdenticalSeries
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";
        string regex = @"(\w)\1+";

        Console.WriteLine(Regex.Replace(text, regex, "$1"));
    }
}

