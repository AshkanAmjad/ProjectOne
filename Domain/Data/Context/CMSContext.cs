using Domain.Entities.Portal.Mapping;
using Domain.Entities.Security.Mapping;
using System.Data.Entity;

namespace Domain.Data.Context
{
    public class CMSContext:DbContext
    {
        public CMSContext():base("name=CMSContext") { }

        public DbSet<ArticleCategoriesMap> ArticleCategories { get; set; }
        public DbSet<ArticlesMap> Articles { get; set; }
        public DbSet<CategoriesMap> Categories { get; set; }
        public DbSet<RolesMap> Roles { get; set; }
        public DbSet<UserRolesMap> UserRoles { get; set; }
        public DbSet<UsersMap> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CMSContext).Assembly);
        }
    }
}
