using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Student : Human, ICommentable
    {
        public int ID { get; private set; }
        public string Comment { get; set; }
    }
}
