using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReverseNIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Stack<int> sequenceOfNums = new Stack<int>();

            while ((input = Console.ReadLine()) != string.Empty)
            {
                sequenceOfNums.Push(int.Parse(input));
            }

            foreach(var num in sequenceOfNums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
