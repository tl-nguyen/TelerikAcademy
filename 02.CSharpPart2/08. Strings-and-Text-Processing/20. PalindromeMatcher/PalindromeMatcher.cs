using System;
using System.Text.RegularExpressions;

class PalindromeMatcher
{
    static bool isPalindrome(string input)
    {
        for (int i = 0; i <= input.Length / 2; i++)
        {
            if (input.Length <= 1 || input[i] != input[input.Length - 1 - i]) return false;
        }

        return true;
    }

    static void Main(string[] args)
    {
        string text = "test palindrome ABBA, palindrome 2 lamal. palindrome 3 exe.";
        string regex = @"\w+";

        MatchCollection matches = Regex.Matches(text, regex);

        foreach (var match in matches)
        {
            if (isPalindrome(match.ToString())) Console.WriteLine(match);
        }
    }
}

