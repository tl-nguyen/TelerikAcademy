using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestSubSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputSeq = new List<int>()
            {
                1, 2, 3, 3, 3, 3, 4, 5
            };
            var longestSeq = LongestSeq(inputSeq);

            foreach(var num in longestSeq)
            {
                Console.WriteLine(num);
            }
        }

        static public List<int> LongestSeq(List<int> sequenceOfNums)
        {
            int max;
            int maxCount = 0;
            int currentNum;
            int currentCount = 0;
            List<int> longestSeq = new List<int>();

            currentNum = sequenceOfNums[0];
            max = currentCount;

            for (var i = 1; i < sequenceOfNums.Count; i++)
            {
                if (currentNum == sequenceOfNums[i])
                {
                    currentCount += 1;
                }
                else
                {
                    currentCount = 1;
                }

                currentNum = sequenceOfNums[i];

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    max = sequenceOfNums[i];
                }
            }

            for (var i = 0; i < maxCount; i++)
            {
                longestSeq.Add(max);
            }

            return longestSeq;
        }
    }
}
