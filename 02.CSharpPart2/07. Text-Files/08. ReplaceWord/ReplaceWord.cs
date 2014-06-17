using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWord
{
    static void Main()
    {
        StreamReader inputStream = new StreamReader(@"..\..\input.txt");
        StreamWriter outputStream = new StreamWriter(@"..\..\output.txt");

        using (inputStream)
        using (outputStream)
        {
            String line;
            while ((line = inputStream.ReadLine()) != null)
            {
                outputStream.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
            }

            Console.WriteLine("Done!! check the output.txt file");
        }
    }
}

