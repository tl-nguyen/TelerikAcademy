using System;
using System.Collections.Generic;
using System.IO;

class SortListOfStrings
{
    static void Main()
    {
        StreamReader inputStream = new StreamReader(@"..\..\input.txt");
        StreamWriter outputStream = new StreamWriter(@"..\..\output.txt");

        using(inputStream)
        using(outputStream)
        {
            List<string> input = new List<string>();
            String line;

            while ((line = inputStream.ReadLine()) != null)
            {
                input.Add(line);
            }

            input.Sort();

            foreach (var item in input)
            {
                outputStream.WriteLine(item);
            }

            Console.WriteLine("Done! check the output.txt file");
        }
    }
}

