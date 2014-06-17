using System;
using System.IO;

class InsertLineNumber
{
    static void Main(string[] args)
    {
        string path = @"..\..\TextFile1.txt";
        StreamReader input = new StreamReader(path);
        path = @"..\..\TextFile2.txt";
        StreamWriter output = new StreamWriter(path);

        using (input)
        using (output)
        {
            int lineNum = 0;
            string line;

            while ((line = input.ReadLine()) != null)
            {
                output.WriteLine(" Line {0} : {1}", lineNum, line);
                lineNum++;
            }
        }

        //Console.WriteLine(new StreamReader(path).ReadToEnd());
    }
}

