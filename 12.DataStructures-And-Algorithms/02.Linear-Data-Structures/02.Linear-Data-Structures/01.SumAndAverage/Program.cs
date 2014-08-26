using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            
            List<int> sequenceOfNums = new List<int>();

            while((input = Console.ReadLine()) != string.Empty)
            {
                sequenceOfNums.Add(int.Parse(input));
            }

            Console.WriteLine("Sum = {0}", sequenceOfNums.Sum());
            Console.WriteLine("Average = {0}", sequenceOfNums.Average());
        }
    }
}
