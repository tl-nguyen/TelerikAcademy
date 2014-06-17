using System;
using System.Text.RegularExpressions;

class EmailMatcher
{
    static void Main()
    {
        string text = "email test blabla@gmail.com, second email :ewd@abv.bg fdasf fda ";
        string regex = @"\w+@\w+\.\w{2,3}";

        MatchCollection matches = Regex.Matches(text, regex);

        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}

