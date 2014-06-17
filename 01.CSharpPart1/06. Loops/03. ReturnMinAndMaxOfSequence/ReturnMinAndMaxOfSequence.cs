using System;

class ReturnMinAndMaxOfSequence
{
    static void Main()
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        int sequenceCounts = 10;

        while ( sequenceCounts > 0)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < min) min = number;
            if (number > max) max = number;

            sequenceCounts--;
        }
        Console.WriteLine("Max = {0}\nMin = {1}",max, min);
    }
}

