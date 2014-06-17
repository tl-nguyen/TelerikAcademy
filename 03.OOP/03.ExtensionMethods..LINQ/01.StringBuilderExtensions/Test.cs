using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace _01.StringBuilderExtensions
{
    class Test
    {
        public static void Main()
        {
            var testMessage = new StringBuilder("this is a test");

            Console.WriteLine(testMessage.Substring(3, 5).ToString());
        }
    }
}
