using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudenNP
{
    public class Test
    {
        public static void Main()
        {
            var student1 = new Student("Test", "test", "test", "a");
            var student2 = new Student("Test2", "test2", "test2", "321333242");

            var student3 = student1.Clone() as Student;

            Console.WriteLine("student1 == student3 : {0}", student1 == student3);
            Console.WriteLine("student1 == student2 (using Equals()) : {0}\n", student1.Equals(student2));

            student3.Ssn = "b";
            Console.WriteLine("Testing deep Clone :\nstudent 1 : {0} student 3 : {1}", student1, student3);

            Console.WriteLine("student1 compareTo student3 : {0}\n", student1.CompareTo(student3));
            Console.WriteLine("student3 compareTo student1 : {0}\n", student3.CompareTo(student1));
        }
    }
}
