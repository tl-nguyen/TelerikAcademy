using System;
using System.Text.RegularExpressions;

class MultiverseCommunication
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(DecriptMessage(input));
    }

    private static string DecriptMessage(string input)
    {
        string[] digits = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        long result = 0;

        for (int i = 0; i < input.Length; i += 3)
        {
            string digitIn13 = input.Substring(i, 3);
            result *= 13;
            result += Array.IndexOf(digits, digitIn13);
        }

        return result.ToString();
    }
}

