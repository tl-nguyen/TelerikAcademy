using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AllPermutationsOfN
{
    class Program
    {
        static void Main()
        {
            var set = 3;
            
            bool[] used = new bool[set];
            

            CalcPermutation(used, new int[set], set, 0);

        }

        
        public static void CalcPermutation(bool[] usedElements, int[] arr, int elementCount, int currrentIndex)
        {
            if (currrentIndex >= elementCount)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    System.Console.Write(arr[i]);
                }

                System.Console.WriteLine();
            }
            else
            {
                for (var i = 0; i < elementCount; i++)
                {
                    if (!usedElements[i])
                    {
                        usedElements[i] = true;
                        arr[currrentIndex] = i + 1;
                        CalcPermutation(usedElements, arr, elementCount, currrentIndex + 1);
                        usedElements[i] = false;
                    }
                } 
            }
        }
    }
}
