using System;
using System.Text;
using System.Text.RegularExpressions;

class URLParser
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";
        string regex = "(.*)://(.*?)(/.*)";

        GroupCollection urlInfo = Regex.Match(url, regex).Groups;

        Console.WriteLine(urlInfo[1]);
        Console.WriteLine(urlInfo[2]);
        Console.WriteLine(urlInfo[3]);
    }
}

