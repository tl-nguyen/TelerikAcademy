using System;
using System.Collections.Generic;

class GreedyDwarf
{
    static void Main()
    {
        int[] valley = ToIntArray(Console.ReadLine().Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries));

        int patternsCount = int.Parse(Console.ReadLine());
        var patterns = new List<string>();
        var maxCoins = int.MinValue;

        for (int i = 0; i < patternsCount; i++)
        {
            patterns.Add(Console.ReadLine());
        }

        for (int i = 0; i < patterns.Count; i++)
        {
            int currentCoins = ProcessPattern(valley, ToIntArray(patterns[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)));
            maxCoins = Math.Max(maxCoins, currentCoins);
        }

        Console.WriteLine(maxCoins);
    }

    static int ProcessPattern(int[] valley, int[] pattern)
    {
        int coins = valley[0];
        int currentPos = 0;
        bool[] visited = new bool[valley.Length];
        visited[0] = true;

        for (int i = 0; ;)
        {
            int nextPos = currentPos + pattern[i];
            
            if (nextPos >= 0 && nextPos < valley.Length && !visited[nextPos])
            {
                coins += valley[nextPos];
                currentPos += pattern[i];
                visited[currentPos] = true;
            }
            else
            {
                return coins;
            }

            i++;

            if (i == pattern.Length) i = 0;
        }
    }

    static int[] ToIntArray(string[] stringArray)
    {
        var intArray = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            intArray[i] = int.Parse(stringArray[i]);
        }

        return intArray;
    }
}

