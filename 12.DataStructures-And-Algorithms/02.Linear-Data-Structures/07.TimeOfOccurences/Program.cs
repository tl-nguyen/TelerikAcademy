using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TimeOfOccurences
{
    class Program
    {
        static IDictionary<int, int> TimeOfOccurences(IList<int> seq)
        {
            IDictionary<int, int> numberOfOccurences = new Dictionary<int, int>();
            IList<int> result = new List<int>();

            foreach (var num in seq)
            {
                if (numberOfOccurences.ContainsKey(num))
                {
                    numberOfOccurences[num]++;
                }
                else
                {
                    numberOfOccurences[num] = 1;
                }
            }

            return numberOfOccurences;
        }

        static void Main(string[] args)
        {
            var timeOfOcurrencesDict = TimeOfOccurences(new List<int>()
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            });

            foreach(var item in timeOfOcurrencesDict)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
