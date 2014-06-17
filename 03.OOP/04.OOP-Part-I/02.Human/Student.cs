using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Student : Human
    {
        public int Grade { get; set; }

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return base.ToString() + " - Grade : " + this.Grade;
        }
    }
}
