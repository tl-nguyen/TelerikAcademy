using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PersonNP
{
    public class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person (string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Name : " + this.Name);

            if (this.Age != null) result.Append(" - Age : " + this.Age);
            else result.Append(" - Age is not specified");

            result.Append("\n");

            return result.ToString();
        }
    }
}
