using Domain.Entites.Security.Model;
using Domain.Entities.Security.Model;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Security.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRoles","Security");
            this.HasKey(k => new { k.RoleId, k.UserId });

            this.HasRequired(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(u => u.UserId);

            this.HasRequired(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(r => r.RoleId);
        }
    }
}
