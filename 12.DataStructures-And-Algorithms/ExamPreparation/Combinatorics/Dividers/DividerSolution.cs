using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dividers
{
    class DividerSolution
    {
        static int digitsCount;
        static int[] digits;
        static int[] minDividersCount;

        static void Main(string[] args)
        {
            digitsCount = int.Parse(Console.ReadLine());
            digits = new int[digitsCount];
            minDividersCount = new int[2];
            minDividersCount[0] = int.MaxValue;

            for(int i = 0; i < digitsCount; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            GeneratePermutations(digits, 0);

            Console.WriteLine(minDividersCount[1]);
        }

        static void GeneratePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                int currentNum = BuildNumber(arr);
                int currentDividerCount = FindDividersCount(currentNum);

                if (currentDividerCount < minDividersCount[0])
                {
                    minDividersCount[0] = currentDividerCount;
                    minDividersCount[1] = currentNum;
                }
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static int BuildNumber(int[] arr)
        {
            int num = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    num += arr[i];
                    continue;
                }
                num = (num + arr[i]) * 10; 
            }

            return num;
        }

        static int FindDividersCount(int num)
        {
            int count = 0;

            for (var i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
