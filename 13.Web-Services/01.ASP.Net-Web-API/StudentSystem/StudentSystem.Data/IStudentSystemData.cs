namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        IRepository<Student> Students { get; }

        IRepository<Course> Courses { get; }

        IRepository<Homework> Homeworks { get; }

        void SaveChanges();
    }
}
