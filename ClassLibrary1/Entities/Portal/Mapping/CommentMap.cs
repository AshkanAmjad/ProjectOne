using ClassLibrary1.Entities.Portal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities.Portal.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.ToTable("Comments", "Portal");
            this.HasKey(k => k.CommentId);

            this.HasRequired(a => a.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(fk => fk.ArticleId);

            this.HasRequired(a => a.User)
                .WithMany(a => a.Comments)
                .HasForeignKey(fk => fk.UserId);

            this.Property(c => c.Content).IsRequired().HasMaxLength(300);
            this.Property(c => c.CreateDate).IsRequired();
            this.Property(c => c.IsActive).IsRequired();
            this.Property(c => c.Title).IsRequired().HasMaxLength(20);
            this.Property(c => c.CommentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
