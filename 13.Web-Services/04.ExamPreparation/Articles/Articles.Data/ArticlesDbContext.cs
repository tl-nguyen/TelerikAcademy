namespace Articles.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Articles.Models;
    using Articles.Data.Migrations;

    public class ArticlesDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
        }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Tag> Tags { get; set; }
    }
}
