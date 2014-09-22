namespace Articles.Data
{
    using Articles.Data.Repositories;
    using Articles.Models;

    public interface IArticlesData
    {
        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Like> Likes { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
