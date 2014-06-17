using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var words = new List<string>();

        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            int newPos = words[i].Length % (n + 1);
            words.Insert(newPos, words[i]);
            if (newPos < i)
            {
                words.RemoveAt(i + 1);
            }
            else
            {
                words.RemoveAt(i);
            }
        }

        var output = new StringBuilder(""); 
        var maxLength = 0;

        foreach (var word in words)
        {
            maxLength = Math.Max(maxLength, word.Length);
        }

        for (int i = 0; i < maxLength; i++)
        {
            foreach (var word in words)
            {
                if (i < word.Length)
                {
                    output.Append(word[i]);
                }
            }
            
        }

        Console.WriteLine(output);
    }
}

