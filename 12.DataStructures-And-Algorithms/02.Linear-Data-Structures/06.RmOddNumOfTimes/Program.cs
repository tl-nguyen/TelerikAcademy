using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RmOddNumOfTimes
{
    class Program
    {
        static IList<int> RemoveOddNumOfTimes(IList<int> seq)
        {
            IDictionary<int, int> numberOfOccurences = new Dictionary<int, int>();
            IList<int> result = new List<int>();

            foreach(var num in seq)
            {
                if(numberOfOccurences.ContainsKey(num))
                {
                    numberOfOccurences[num]++;
                } 
                else
                {
                    numberOfOccurences[num] = 1;
                }
            }

            foreach(var num in seq)
            {
                if(numberOfOccurences[num] % 2 == 0)
                {
                    result.Add(num);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var removedOddNumOfTimes = RemoveOddNumOfTimes(new List<int>()
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            });

            foreach(var num in removedOddNumOfTimes)
            {
                Console.WriteLine(num);
            }
        }
    }
}
