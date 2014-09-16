using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CombsWithoutDuplicates
{
    class Program
    {
        static void Main()
        {
            var elementSet = 3;
            var size = 2;
            GenerateCombinations(new int[size], 0, 0, elementSet);
        }

        public static void GenerateCombinations(int[] arr, int currentIndex, int currentValueFrom, int elementSet)
        {
            if (currentIndex == arr.Length)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    System.Console.Write(arr[i]);
                }

                System.Console.WriteLine();

                return;
            }

            for (var i = currentValueFrom; i < elementSet; i++)
            {
                arr[currentIndex] = i + 1;
                GenerateCombinations(arr, currentIndex + 1, i + 1, elementSet);
            }
        }
    }
}
