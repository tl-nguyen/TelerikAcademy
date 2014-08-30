using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NumOfOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new double[]
            {
                3, 4, 4, -2.5, 3, 3, 4, 3, -2.5
            };

            var occurences = new Dictionary<double, int>();

            foreach (var num in nums)
            {
                if (!occurences.ContainsKey(num))
                {
                    occurences[num] = 1;
                }
                else
                {
                    occurences[num]++;
                }
            }

            foreach(var item in occurences)
            {
                Console.WriteLine(item.Key + "->" + item.Value + " times");
            }
        }
    }
}
