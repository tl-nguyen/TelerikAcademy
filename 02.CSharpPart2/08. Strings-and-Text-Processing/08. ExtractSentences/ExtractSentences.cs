using System;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else."
                       +" Inside the submarine is very tight. So we are drinking all the day."
                       +" We will move out of it in 5 days.";
        string word = "tight";
        string regex = @"\s*([^\.]*\b" + word + @"\b[^\.]*\.)";
        MatchCollection matches = Regex.Matches(text, regex);

        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}

