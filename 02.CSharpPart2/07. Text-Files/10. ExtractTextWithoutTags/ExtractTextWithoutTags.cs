using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractTextWithoutTags
{
    static void Main()
    {
        StreamReader inputStream = new StreamReader(@"..\..\input.txt");

        using (inputStream)
        {
            int c;
            StringBuilder text = new StringBuilder("");
            while ((c = inputStream.Read()) != -1)
            {
                if (c == '>')
                {
                    while ((c = inputStream.Read()) != -1 && c != '<')
                    {
                        text.Append((char)c);
                    }
                    text.Append("\n");
                }
            }

            Console.WriteLine(text.ToString());
        }
    }
}

