using System;
using System.IO;

class ReplaceSubString
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
                outputStream.WriteLine(line.Replace("start", "finish"));
            }

            Console.WriteLine("Done!! check the output.txt file");
        }
    }
}

