using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DefineException
{
    class InvalidRangeException<T> : ApplicationException
    {
        private const string message = "Out of range";
        public InvalidRangeException() : base(message)
        {
        }
    }
}
