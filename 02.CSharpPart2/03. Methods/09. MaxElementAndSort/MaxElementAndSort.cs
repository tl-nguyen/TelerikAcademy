using System;

class MaxElementAndSort
{
    static void Main()
    {
        int[] arr = { -1, -3, 4, -5, 6, -7 };

        SelectionSort(arr);
        PrintArray(arr);

        SelectionSort(arr, descending: true);
        PrintArray(arr);
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + (i == arr.Length - 1 ? "\n" : " "));
    }

    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static int GetMaxFromPosition(int[] arr, int i, bool descending)
    {
        int best = i;

        for (i++; i < arr.Length; i++)
            if (descending ? arr[i] < arr[best] : arr[best] < arr[i])
                best = i;

        return best;
    }

    static void SelectionSort(int[] arr, bool descending = false)
    {
        for (int i = 0; i < arr.Length; i++)
            Swap(arr, i, GetMaxFromPosition(arr, i, descending));
    }

    
}

