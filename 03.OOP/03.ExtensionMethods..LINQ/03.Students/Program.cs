using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        var students = new[]
        {
            new { FirstName = "Bla", LastName = "Lala", Age = 30},
            new { FirstName = "Ala", LastName = "Nala", Age = 20},
            new { FirstName = "Vla", LastName = "Mala", Age = 25},
            new { FirstName = "Hla", LastName = "Aala", Age = 23}
        };

        Print(students.Where(
            student => student.FirstName.CompareTo(student.LastName) < 0
        ));

        Print(students.Where(
            student => student.Age >= 18 && student.Age <= 24
        ));

        //lambda
        Print(students
            .OrderByDescending(
                student => student.FirstName
            ).ThenByDescending(
                student => student.LastName
        ));

        //linq
        Print(
            from student in students
            orderby student.FirstName descending,
                    student.LastName descending
            select student
        );

    }

    public static void Print(IEnumerable students)
    {
        foreach (var item in students)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}

