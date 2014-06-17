using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Human : ICommentable
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        public Human()
        {
        }

        public Human(string name)
        {
            this.Name = name;
        }
    }
}
