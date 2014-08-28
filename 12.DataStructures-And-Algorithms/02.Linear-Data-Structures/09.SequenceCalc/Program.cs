using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SequenceCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> seq = CalculateSequence(2);
            
            foreach(var num in seq)
            {
                Console.WriteLine(num);
            }
        }

        private static Queue<int> CalculateSequence(int firstNumber)
        {
            Queue<int> resultQueue = new Queue<int>();
            Queue<int> calculationNums = new Queue<int>();
            int currentNumber = firstNumber;

            resultQueue.Enqueue(currentNumber);
            calculationNums.Enqueue(currentNumber);

            for (var i = 0; i < 17; i++ )
            {
                var nextNum = calculationNums.Dequeue() + 1;
                resultQueue.Enqueue(nextNum);
                calculationNums.Enqueue(nextNum);
                resultQueue.Enqueue(2 * (nextNum - 1) + 1);
                calculationNums.Enqueue(2 * (nextNum - 1) + 1);
                resultQueue.Enqueue(nextNum + 1);
                calculationNums.Enqueue(nextNum + 1);
            }

            return resultQueue;
        }
    }
}
