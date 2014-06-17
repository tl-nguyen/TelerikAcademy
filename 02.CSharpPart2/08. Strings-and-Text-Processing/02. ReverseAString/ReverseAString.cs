using System;

class ReverseAString
{
    static string Reverse(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(Reverse(input));
    }
}

