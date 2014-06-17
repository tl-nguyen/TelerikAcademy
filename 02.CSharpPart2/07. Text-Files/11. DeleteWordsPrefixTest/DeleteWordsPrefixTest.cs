using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsPrefixTest
{
    static void Main()
    {
        StreamReader input = new StreamReader("../../input.txt");
        StreamWriter output = new StreamWriter("../../output.txt");

        using (input)
        using (output)
        {
            string line; 
            while ((line = input.ReadLine()) != null)
            {
                output.WriteLine(Regex.Replace(line, @"\btest\w*\b", String.Empty));
            }
        }
    }
}

