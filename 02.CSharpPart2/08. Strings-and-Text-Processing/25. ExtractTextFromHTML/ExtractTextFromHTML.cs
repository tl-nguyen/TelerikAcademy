using System;
using System.Text.RegularExpressions;

class ExtractTextFromHTML
{
    static void Main()
    {
        string text = @"<html>"
                        + "<head><title>News</title></head>"
                        + "<body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>"
                        + "aims to provide free real-world practical training "
                        + "for young people who want to turn into skillful .NET software engineers.</p>"
                        + "</body>"
                        + "</html>";
        string regex = "<.+?>";

        Console.WriteLine(Regex.Replace(text, regex, " ").Trim());
    }
}
