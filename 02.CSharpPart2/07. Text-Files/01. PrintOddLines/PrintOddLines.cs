using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        string path = @"..\..\test.txt";

        StreamReader streamReader = new StreamReader(path);

        using(streamReader)
        {
            int lineNum = 1;
            string line;
            while((line = streamReader.ReadLine()) != null)
            {
                if (lineNum % 2 == 0) Console.WriteLine(line);
                lineNum++;
            }
        }
    }
}

