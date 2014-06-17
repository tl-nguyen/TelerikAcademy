using System;

class PrintMembersOfTheSequence
{
    static void Main(string[] args)
    {
        int countsToPrint = 10;
        int numberToStart = 2;

        for (int counter = 1; counter <= countsToPrint; counter++)
        {
            Console.WriteLine(numberToStart);
            numberToStart = -(numberToStart + ((numberToStart > 0) ? 1 : -1));
        }
    }
}

