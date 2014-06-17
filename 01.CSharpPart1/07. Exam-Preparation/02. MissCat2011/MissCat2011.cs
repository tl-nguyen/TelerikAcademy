using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] juryVotes = new int[n];
        int[] cats = new int[10];
        int maxVote = -1;
        int winner = -1;

        for (int i = 0; i < n; i++)
        {
            juryVotes[i] = int.Parse(Console.ReadLine());
        }

        foreach (var juryVote in juryVotes)
        {
            cats[juryVote-1]++;
        }

        for (int i = 0; i < cats.Length; i++)
        {
            if(cats[i] > maxVote)
            {
                maxVote = cats[i];
                winner = i;
            }
        }

        Console.WriteLine(winner+1);
    }
}

