using System;
using System.IO;

class CompareTextFiles
{
    static void Main()
    {
        StreamReader file1 = new StreamReader(@"..\..\TextFile1.txt");
        StreamReader file2 = new StreamReader(@"..\..\TextFile2.txt");
        int match = 0;
        int notMatch = 0;

        using (file1)
        using (file2)
        {
            
            String line;

            while ((line = file1.ReadLine()) != null)
            {
                if (line.Equals(file2.ReadLine())) match++;
                else notMatch++;
            }
        }

        Console.WriteLine("matched lines = {0}, not matched lines = {1}", match, notMatch);
    }
}

