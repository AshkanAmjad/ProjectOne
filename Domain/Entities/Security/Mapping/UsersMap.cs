using Domain.Entites.Security.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Domain.Entities.Security.Mapping
{
    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.ToTable("Users");
            this.HasKey(k => k.UserId);
            this.Property(u => u.UserName).IsRequired().HasMaxLength(10);
            this.Property(p => p.Password).IsRequired().HasMaxLength(10);
        }
    }
}
