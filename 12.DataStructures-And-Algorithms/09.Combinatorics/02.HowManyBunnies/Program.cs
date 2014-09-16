using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HowManyBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int askedBunniesCount = int.Parse(Console.ReadLine());
            int[] bunnyAnswers = new int[askedBunniesCount];

            for (var i = 0; i < askedBunniesCount; i++)
            {
                bunnyAnswers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(CalculateMinimumSecond(bunnyAnswers));
        }

        private static int CalculateMinimum(int[] bunnyAnswers)
        {
            int[] cache = new int[1000001];
            
            int minimum = 0;

            for (int i = 0; i < bunnyAnswers.Length; i++)
            {
                cache[bunnyAnswers[i] + 1]++;

                if (cache[bunnyAnswers[i] + 1] == bunnyAnswers[i] + 1)
                {
                    minimum += bunnyAnswers[i] + 1;
                    cache[bunnyAnswers[i] + 1] = 0;
                }
            }

            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0) 
                    continue;
                else minimum += i;
            }

            return minimum;
        }

        private static int CalculateMinimumSecond(int[] bunnyAnswers)
        {
            int[] cache = new int[1000001];

            int minimum = 0;

            for (int i = 0; i < bunnyAnswers.Length; i++)
            {
                cache[bunnyAnswers[i] + 1]++;
            }

            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0)
                {
                    continue;
                }
                if (cache[i] <= i)
                {
                    minimum += i;
                }
                else
                {
                    minimum += (int) Math.Ceiling((double) cache[i] / i) * i;
                }
            }

            return minimum;
        }
    }
}
