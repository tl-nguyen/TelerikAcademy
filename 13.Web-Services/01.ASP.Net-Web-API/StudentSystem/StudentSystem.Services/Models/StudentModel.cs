namespace StudentSystem.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Model;
    using System.ComponentModel.DataAnnotations;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Number = s.Number
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Number { get; set; }
    }
}