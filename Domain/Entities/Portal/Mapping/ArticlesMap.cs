using Domain.Entites.Portal.Model;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Portal.Mapping
{
    public class ArticlesMap : EntityTypeConfiguration<Articles>
    {
        public ArticlesMap()
        {
            this.ToTable("Articles","Portal");
            this.HasKey(k => k.ArticleId);
            this.HasRequired(a => a.Author).WithMany(a => a.Artice).HasForeignKey(fk => fk.AuthorId);
            this.Property(t => t.Title).IsRequired().HasMaxLength(100);
            this.Property(c => c.Content).IsRequired();
            this.Property(d => d.PublishDate).IsRequired();
        }
    }
}
