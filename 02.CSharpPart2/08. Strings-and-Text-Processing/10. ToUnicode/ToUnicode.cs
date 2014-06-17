using System;
using System.Text;

    class ToUnicode
    {
        static string ConvertToUnicode(string text)
        {
            StringBuilder unicodeText = new StringBuilder();

            foreach (char ch in text)
            {
                unicodeText.AppendFormat(@"\u{0:X4}", (int)ch);
            }

            return unicodeText.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToUnicode("hi!"));
        }
    }

