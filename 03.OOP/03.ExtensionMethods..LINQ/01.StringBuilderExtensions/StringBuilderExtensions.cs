using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            StringBuilder output = new StringBuilder(input.ToString().Substring(index, length));

            return output;
        }
    }
}
