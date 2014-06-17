using System;

class PrintAllCards
{
    static void Main()
    {
        String[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        String[] suits = { "spades", "diamonds", "hearts", "clubs" };

        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < names.Length; j++)
            {
                Console.WriteLine("{0} of {1}", names[j], suits[i]);
            }
        }
    }
}

