using System;

class BiggerThanNeighborsIndex
{
    static void Main()
    {
        int[] arr = { 0, 32, 12, 22, 22, 1, 22, 13, 32, 12, 1, 12 };
        int index = IndexOfBiggerThanNeighbors(arr);
        Console.WriteLine("Index of the first element in arr that is bigger than its neighbors : {0}", index != -1 ? index.ToString() : "No such element" );
    }

    static public int IndexOfBiggerThanNeighbors(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (isBiggerThanNeighbors(arr, i)) return i;
        }
        return -1;
    }

    static public Boolean isBiggerThanNeighbors(int[] arr, int pos)
    {
        Boolean isBigger = false;
        if (pos <= 0 || pos >= (arr.Length - 2)) return isBigger;
        if (arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1]) isBigger = true;
        return isBigger;
    }
}

