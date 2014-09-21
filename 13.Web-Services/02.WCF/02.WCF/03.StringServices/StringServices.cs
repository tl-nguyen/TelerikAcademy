using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringServices" in both code and config file together.
    public class StringServices : IStringServices
    {
        public int OccurencesCount(string first, string second)
        {
            int i;
            int occurences = 0;
            while ((i = first.IndexOf(second)) != -1)
            {
                occurences++;
            }

            return occurences;
        }
    }
}
