namespace Articles.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Articles.Data.Repositories;
    using Articles.Models;

    public class AlertsData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public AlertsData(ArticlesDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public AlertsData()
            : this (new ArticlesDbContext())
        {
        }

        public IRepository<Alert> Alerts
        {
            get { return this.GetRepository<Alert>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
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
    }
}
