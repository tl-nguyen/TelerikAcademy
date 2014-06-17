using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DefineException
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                int number = 101;

                if (number < 1 || number > 100) throw new InvalidRangeException<int>();
            }
            catch(InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                DateTime date = new DateTime(1940, 2, 2);

                if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31)) throw new InvalidRangeException<DateTime>();
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
