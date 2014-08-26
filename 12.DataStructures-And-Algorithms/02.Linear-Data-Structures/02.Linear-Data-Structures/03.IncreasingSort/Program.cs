using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.IncreasingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            List<int> sequenceOfNums = new List<int>();

            while ((input = Console.ReadLine()) != string.Empty)
            {
                sequenceOfNums.Add(int.Parse(input));
            }

            sequenceOfNums.Sort();

            foreach(var num in sequenceOfNums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
