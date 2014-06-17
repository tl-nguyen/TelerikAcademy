using System;

class TextCount
{
    private static int SubStringCount(string text, string subString)
    {
        int count = 0;
        int currentInd = -1;

        while((currentInd = text.IndexOf(subString, currentInd + 1)) != -1)
        {
           count++;
        }

        return count;
    }

    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine" 
                        + "is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string subString = "in";

        Console.WriteLine(SubStringCount(text.ToLower(), subString.ToLower()));
    }
}

