using ClassLibrary1.Entities.Portal.Model;
using Domain.Entites.Portal.Model;
using Domain.Entites.Security.Model;
using Domain.Entities.Security.Model;
using System.Data.Entity;

namespace Domain.Data.Context
{
    public class CMSContext : DbContext
    {
        public CMSContext() : base("name=CMS_DB") { }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CMSContext).Assembly);
        }
    }
}
