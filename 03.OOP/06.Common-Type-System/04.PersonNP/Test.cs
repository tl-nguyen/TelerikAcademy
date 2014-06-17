using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PersonNP
{
    public class Test
    {
        public static void Main()
        {
            var normalPerson = new Person("Ivan", 25);
            var unAgedPerson = new Person("Pesho");
            Console.WriteLine(normalPerson);
            Console.WriteLine(unAgedPerson);
        }
    }
}
