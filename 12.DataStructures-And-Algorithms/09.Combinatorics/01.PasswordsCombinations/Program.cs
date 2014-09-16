namespace _01.PasswordsCombinations
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var numOfStars = 0;

            foreach (var ch in input)
            {
                if (ch == '*')
                {
                    numOfStars++;
                }
            }

            Console.WriteLine(Math.Pow(2, numOfStars));
        }
    }
}
