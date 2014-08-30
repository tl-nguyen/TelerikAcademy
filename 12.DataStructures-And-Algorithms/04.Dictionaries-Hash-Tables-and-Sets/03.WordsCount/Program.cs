using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../words.txt";
            string content;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    content = sr.ReadToEnd();
                    CountsOfAllWord(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static void CountsOfAllWord(string content)
        {
            var wordCounts = new SortedDictionary<string, int>();
            var words = content.Split(new char[] { ' ', ',', '-', '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word.ToLower()))
                {
                    wordCounts[word.ToLower()] = 1;
                }
                else
                {
                    wordCounts[word.ToLower()]++;
                }
            }

            foreach (var count in wordCounts)
            {
                Console.WriteLine(count.Key + " -> " + count.Value);
            }

        }


    }
}
