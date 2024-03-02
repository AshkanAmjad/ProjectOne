using Domain.Entites.Portal.Model;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Portal.Mapping
{
    public class ArticleCategoryMap : EntityTypeConfiguration<ArticleCategory>
    {
        public ArticleCategoryMap()
        {
            this.ToTable("ArticleCategories","Portal");
            this.HasKey(k => new { k.ArticleId, k.CategoryId });

            this.HasRequired(a => a.Article)
                .WithMany(ac => ac.ArticeCategory)
                .HasForeignKey(a => a.ArticleId);

            this.HasRequired(c => c.Category)
                .WithMany(ac => ac.ArticeCategory)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
