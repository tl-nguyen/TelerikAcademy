using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal
{
    class Cat : Animal, ISound
    {
        public Cat(string name, int age, char sex) : base(name, age, sex)
        {

        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Meow..meow..");
        }
    }
}
