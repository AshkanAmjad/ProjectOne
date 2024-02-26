using System;
using System.Collections.Generic;

namespace Domain.Entities.Security.Model
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Title { get; set; }

        #region
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
