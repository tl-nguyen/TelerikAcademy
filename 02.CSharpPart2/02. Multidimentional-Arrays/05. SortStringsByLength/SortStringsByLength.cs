using System;

class SortStringsByLength
{
    static void Main()
    {
        String[] arr = { "hello", "blablabla", "tcwsdf", "fdasfasdssaadfs", "ddd" };
        Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}

