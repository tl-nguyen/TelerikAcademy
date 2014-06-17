using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Teacher : Human, ICommentable
    {
        public List<Discipline> Disciplines { get; private set; }
        public string Comment { get; set; }
    }
}
