using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = new int[]
            {
                2,3,4,1,4,12,3,14,2131,21,231,343
            };

            //lambda
            Print(
                numbers
                    .Where(number => (number % 7 == 0) && (number % 3 == 0))
            );

            //linq
            Print(
                from number in numbers
                where (number % 7 == 0) && (number % 3 == 0)
                select number
            );
        }

        public static void Print(IEnumerable items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
