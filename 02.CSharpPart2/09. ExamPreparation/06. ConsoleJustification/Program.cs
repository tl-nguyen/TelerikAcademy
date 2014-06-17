using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.ConsoleJustification
{
    class Program
    {
        static int totalLines;
        static int lineWidth;
        static List<string> text;
        static int reachedWordsLength = 0;

        static void Main(string[] args)
        {
            InputData();

            var words = CollectWords(text);
            int i = 0;

            
            Console.WriteLine(BuildLine(words));
                
			
        }

        private static string BuildLine(List<string> words)
        {
            StringBuilder resultLine = new StringBuilder();
            int wordIndex = 0;
            int currentLineLength = 0;
            int wordsLength = 0;

            do
            {
                resultLine.Append(words[wordIndex] + " ");
                wordsLength += words[wordIndex].Length;
                wordIndex++;
            } while ((currentLineLength += words[wordIndex].Length + 1) <= lineWidth + 1);

            int spacesLength = currentLineLength - wordsLength;
            int cap = (spacesLength / wordIndex) + (spacesLength % wordIndex);

            string result = Regex.Replace(resultLine.ToString(), @" ", new string(' ', cap));
            reachedWordsLength += wordIndex + 1;

            return result;
        }

        static void InputData()
        {
            totalLines = int.Parse(Console.ReadLine());
            lineWidth = int.Parse(Console.ReadLine());
            text = new List<string>();

            for (int i = 0; i < totalLines; i++)
            {
                text.Add(Console.ReadLine());
            }
        }

        static List<string> CollectWords(List<string> text)
        {
            var words = new List<string>();

            foreach (var line in text)
            {
                string[] tempLineWords = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in tempLineWords)
                {
                    words.Add(word);
                }
            }

            return words;
        }
    }
}
