
using System;
using System.Collections;
namespace _11.ShortestSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue seq = CalculateShortestSeq(5, 16);
        }

        private static Queue CalculateShortestSeq(int p1, int p2)
        {
            Queue calculatedSeq = new Queue();
            int[] operations = new int[3] {1, 2, 3};



            return calculatedSeq;
        }

        private static Nullable<int> Operate(int input, int operation)
        {
            switch(operation)
            {
                case 1:
                    return input + 1;
                case 2:
                    return input + 2;
                case 3:
                    return input * 2;
            }
            return null;
        }
    }
}
