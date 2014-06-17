using System;

class BiggerThanNeighbors
{
    static void Main()
    {
        int[] arr = { 0, 32, 12, 22, 22, 1, 22, 13, 32, 12, 1, 12 };
        int pos = 2;

        isBiggerThanNeighbors(arr, pos);
    }

    static public Boolean isBiggerThanNeighbors(int[] arr, int pos)
    {
        Boolean isBigger = false;
        if (pos <= 0 || pos >= (arr.Length - 2))
        {
            Console.WriteLine("Such element at this position, that has two neighbors doesn't exist");
            return isBigger;
        }
        if (arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1]) isBigger = true;
        Console.WriteLine("Is it bigger than its neighbors ? - {0}", isBigger ? "YES" : "NO");
        return isBigger;
    }
}

