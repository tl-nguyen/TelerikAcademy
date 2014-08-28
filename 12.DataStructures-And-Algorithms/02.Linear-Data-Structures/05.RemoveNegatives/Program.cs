using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegatives
{
    class Program
    {
        static void Main(string[] args)
        {
            var seq = new List<int>()
            {
                1, -2, 3, -1, 2, 3, -5
            };

            for(var i = 0; i < seq.Count; i++)
            {
                if(seq[i] < 0)
                {
                    seq.RemoveAt(i);
                }
            }

            foreach(var num in seq)
            {
                Console.WriteLine(num);
            }

        }
    }
}
