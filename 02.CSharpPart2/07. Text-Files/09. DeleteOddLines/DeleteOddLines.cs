using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static List<string> GetEvenLines()
    {
        List<string> lines = new List<string>();
        int lineNum = 1;

        using (StreamReader input = new StreamReader("../../input.txt"))
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                if (lineNum % 2 == 0) lines.Add(line);
                lineNum++;
            }
        }

        return lines;
    }

    static void WriteToFile(List<string> lines)
    {
        using (StreamWriter output = new StreamWriter("../../input.txt"))
        {
            foreach (string line in lines)
            {
                output.WriteLine(line);
            }
            Console.WriteLine("Done!! check the output.txt file");
        }
    }

    static void Main()
    {
        WriteToFile(GetEvenLines());
    }
}

