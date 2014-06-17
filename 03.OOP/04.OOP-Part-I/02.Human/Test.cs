using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Test
    {
        public static void Main()
        {
            var students = new List<Student>
            {
                new Student("Pesho", "Tonchev", 4),
                new Student("Petq", "Toncheva", 6),
                new Student("Ivan", "Ivanov", 4),
                new Student("Ivana", "Ivanova", 10),
                new Student("Lili", "Boneva", 9),
                new Student("Gosho", "Goshev", 12),
                new Student("Antonia", "Stamatova", 3),
                new Student("Nikol", "Stamenova", 11),
                new Student("Dimityr", "Dimitrov", 13),
                new Student("Kalin", "Marinov", 11)
            };


            var workers = new List<Worker>
            {
                new Worker("Bill", "Gates", 100000, 8),
                new Worker("Steve", "Jobs", 50000, 5),
                new Worker("Carlos", "Helu", 110000, 8),
                new Worker("Armancio", "Ortega", 70000, 8),
                new Worker("Warren", "Buffett", 68000, 8),
                new Worker("Larry", "Ellison", 63000, 8),
                new Worker("Charles", "Koch", 52000, 8),
                new Worker("David", "Koch", 52000, 10),
                new Worker("Li", "Ka-sing", 50000, 8),
                new Worker("Bernard", "Arnault", 34000, 4)
            };

            var people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);

            Print(students.OrderBy(student => student.Grade));
            Print(workers.OrderByDescending(worker => worker.MoneyPerHour()));
            Print(people.OrderBy(person => person.FirstName).ThenBy(person => person.LastName));
        }

        public static void Print(IEnumerable items)
        {
            foreach (var item in items) 
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
