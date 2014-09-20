namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public StudentSystemData()
            : this (new StudentSystemDbContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
        }

        public IRepository<Student> Students
        {
            get
            {
                return this.GetRepository<Student>();
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IRepository<Homework> Homeworks
        {
            get
            {
                return this.GetRepository<Homework>();
            }
        }

        private IRepository<T> GetRepository<T>() where T: class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(Repository<T>);
                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
