using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GeneratingVariations
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = 3;
            int elementsPerSet = 2;
            string[] set = new string[3]
            {
                "hi", "a", "b"
            };

            GenerateVariations(new string[elementsPerSet], set, 0, elementsCount);
        }

        public static void GenerateVariations(string[] arr, string[] set, int currentIndex, int elementsCount)
        {
            if (currentIndex == arr.Length)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    System.Console.Write(arr[i] + " ");
                }
                System.Console.WriteLine();
            }
            else
            {
                for (var i = 0; i < elementsCount; i++)
                {
                    arr[currentIndex] = set[i];
                    GenerateVariations(arr, set, currentIndex + 1, elementsCount);
                } 
            }
        }
    }
}
