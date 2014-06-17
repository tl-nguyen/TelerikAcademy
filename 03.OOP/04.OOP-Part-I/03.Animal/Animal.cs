using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        protected readonly char sex;

        public Animal(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.sex = sex;
        }
    }
}
