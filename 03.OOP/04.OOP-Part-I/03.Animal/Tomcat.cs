using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal
{
    class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, 'M')
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwwww");
        }
    }
}
