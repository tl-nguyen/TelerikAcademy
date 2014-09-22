﻿namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        private IStudentSystemDbContext context;
        private IDbSet<T> set;

        public Repository()
            : this(new StudentSystemDbContext())
        {

        }

        public Repository(IStudentSystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            //this.ChangeEntityState(entity, EntityState.Added);
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}