using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Domain.Entities.Security.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Roles", "Security");
            this.Property(r => r.RoleId).IsRequired();
            this.Property(t => t.Title).IsRequired().HasMaxLength(100);
        }
    }
}
