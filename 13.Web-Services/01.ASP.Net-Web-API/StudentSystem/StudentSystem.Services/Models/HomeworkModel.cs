namespace StudentSystem.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Model;
    using System.ComponentModel.DataAnnotations;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    Id = h.Id,
                    Content = h.Content,
                    TimeSent = h.TimeSent
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}