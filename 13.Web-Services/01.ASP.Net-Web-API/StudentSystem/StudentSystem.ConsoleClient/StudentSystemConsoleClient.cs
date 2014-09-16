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
            var dbContext = new StudentSystemDbContext();

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

            var savedStudent = dbContext.Students.First();
            Console.WriteLine(savedStudent.Name);
        }
    }
}
