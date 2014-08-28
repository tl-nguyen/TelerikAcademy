using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindMajorant
{
    class Program
    {
        public static int FindMajorant(IList<int> seq)
        {
            IDictionary<int, int> numberOfOccurences = new Dictionary<int, int>();
            IList<int> result = new List<int>();
            int majorant = seq[0];

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

            foreach (var item in numberOfOccurences)
            {
                if (item.Value >= (seq.Count / 2 + 1))
                {
                    majorant = item.Key;
                }
            }

            return majorant;
        }

        static void Main(string[] args)
        {
            var majorant = FindMajorant(new List<int>()
            {
                2, 2, 3, 3, 2, 3, 4, 3, 3
            });

            Console.WriteLine(majorant);
        }
    }
}
