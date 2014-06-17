using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal
{
    class Test
    {
        public static void Main()
        {
            var animalList = new List<Animal>
            {
                new Cat("Pesho", 5, 'M'),
                new Kitten("Mila", 1),
                new Kitten("Marina", 2),
                new Tomcat("Pepi", 1),
                new Tomcat("Colio", 2),
                new Dog("Bruno", 3, 'M'),
                new Dog("Dajv", 3, 'F'),
                new Frog("FrogPrince", 6, 'M'),
                new Frog("FrogPrincess", 4, 'F'),
            };

            Console.WriteLine("Average age of Cats = " + animalList.Where(cat => cat is Cat).Average(cat => cat.Age));
            Console.WriteLine("Average age of Dogs = " + animalList.Where(dog => dog is Dog).Average(dog => dog.Age));
            Console.WriteLine("Average age of Frogs = " + animalList.Where(frog => frog is Frog).Average(frog => frog.Age));
        }
    }
}
