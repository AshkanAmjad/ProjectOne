using System;
using System.Collections.Generic;

namespace Domain.Entities.Security.Model
{
    public class Roles
    {
        public Guid RoleId { get; set; }
        public string Title { get; set; }

        #region
        public ICollection<UserRoles> UserRoles { get; set; }
        #endregion
    }
}
