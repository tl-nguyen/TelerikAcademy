namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class StudentSystemConsoleClient
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentSystemData();

            var student = new Student
            {
                Name = "Petyr",
                Number = "3123"
            };

            student.Courses.Add(new Course
                {
                    Name = "Databases"
                });

            dbContext.Students.Add(student);
            dbContext.SaveChanges();

            var savedStudents = dbContext.Students.All();
            
            foreach (var stud in savedStudents)
            {
                Console.WriteLine(stud.Name);
            }
        }
    }
}
