using System;
using System.IO;

class TextFilesConcatenation
{
    static void Main()
    {
        string path = @"..\..\TextFile1.txt";
        StreamReader textFile1 = new StreamReader(path);
        path = @"..\..\TextFile2.txt";
        StreamReader textFile2 = new StreamReader(path);
        path = @"..\..\TextFile1AndTextFile2.txt";
        StreamWriter concatTextFile = new StreamWriter(path, true);

        using (textFile1)
        using (textFile2)
        using (concatTextFile)
        {
            concatTextFile.WriteLine(textFile1.ReadToEnd());
            concatTextFile.WriteLine(textFile2.ReadToEnd());
        }

        //Console.WriteLine(new StreamReader(path).ReadToEnd());
    }
}

