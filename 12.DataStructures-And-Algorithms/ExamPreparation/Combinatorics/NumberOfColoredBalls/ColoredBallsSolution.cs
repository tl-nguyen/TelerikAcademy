using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfColoredBalls
{
    class ColoredBallsSolution
    {
        static HashSet<string> allPers;
     
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = input.Length;
            char[] balls = new char[count];
            allPers = new HashSet<string>();

            for (var i = 0; i < count; i++)
            {
                balls[i] = input[i];
            }

            PermuteRep(balls, 0, count);

            Console.WriteLine(allPers.Count);
        }

        static void PermuteRep(char[] arr, int start, int n)
        {
            allPers.Add(new string(arr));

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
