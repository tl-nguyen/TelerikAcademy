using System;

class MaxSequence
{
    static void Main()
    {
        int[] arr = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int current = arr[0];
        int sequenceCount = 1;
        int maxSequence = 1;
        int maxSequenceVal = current;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == current)
            {
                sequenceCount++;
            }
            else
            {
                sequenceCount = 1;
                current = arr[i];
            }
        }

        for (int i = 0; i < sequenceCount; i++)
        {
            Console.Write("{0} ", current);
        }
    }
}

