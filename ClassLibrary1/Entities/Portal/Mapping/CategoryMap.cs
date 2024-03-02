using Domain.Entites.Portal.Model;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Portal.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Categories", "Portal");
            this.HasKey(k => k.CategoryId);
            this.Property(t => t.Title).IsRequired().HasMaxLength(100);
            this.Property(a => a.IsActive).IsRequired();
        }
    }
}
