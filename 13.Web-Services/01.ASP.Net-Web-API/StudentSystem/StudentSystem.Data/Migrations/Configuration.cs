namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            Random randGenerator = new Random();

            var firstHomework = new Model.Homework
            {
                Content = "first homework",
                TimeSent = new DateTime(2014, 1, 1)
            };

            for (var i = 0; i < 200; i++)
            {
                var newStudent = new Model.Student
                {
                    Name = "Student" + i,
                    Number = randGenerator.Next(1000, 9999).ToString()
                };

                newStudent.Homeworks.Add(firstHomework);

                context.Students.Add(newStudent);
            }

            for (var i = 0; i < 20; i++)
            {
                var newCourse = new Model.Course
                {
                    Name = "Course" + i,
                    Description = "description" + i,
                    Materials = "materials" + i,
                };

                newCourse.Homeworks.Add(firstHomework);
                
                context.Courses.Add(newCourse);
            }

            context.SaveChanges();
        }
    }
}
