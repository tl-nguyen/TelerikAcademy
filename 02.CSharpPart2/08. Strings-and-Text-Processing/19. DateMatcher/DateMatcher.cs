using System;
using System.Globalization;
using System.Text.RegularExpressions;

class DateMatcher
{
    static void Main()
    {
        string text = "date test 28.08.2018, second date :29.01.2012 fdasf fda ";
        string regex = @"\d{2}\.\d{2}\.\d{4}";

        MatchCollection matches = Regex.Matches(text, regex);

        foreach (var match in matches)
        {
            Console.WriteLine(DateTime.ParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture)
                                    .ToString(CultureInfo.GetCultureInfo("en-CA")));
        }
    }
}

