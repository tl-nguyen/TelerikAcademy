using System;
using System.Text.RegularExpressions;

class AnchorTagsToSquareBrackets
{
    static void Main()
    {
        string text = "<p>Please visit "
                      + "<a href=\"http://academy.telerik.com\">"
                      + "our site"
                      + "</a> to choose a training course. Also visit "
                      + "<a href=\"www.devbg.org\">"
                      + "our forum"
                      + "</a> to discuss the courses.</p>";
        string regex = "<a\\s+href=\"(.+?)\">(.+?)</a>";

        string result = Regex.Replace(text, regex, match => "[URL=" + match.Groups[1].Value + "]" + match.Groups[2].Value + "[/URL]");
        Console.WriteLine(result); 
    }
}

