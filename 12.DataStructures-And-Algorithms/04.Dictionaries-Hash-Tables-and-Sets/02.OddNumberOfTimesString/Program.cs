using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OddNumberOfTimesString
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new string[]
            {
                "C#", "SQL", "PHP", "PHP", "SQL", "SQL"
            };

            var occurences = new Dictionary<string, int>();

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

            foreach (var item in occurences)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
