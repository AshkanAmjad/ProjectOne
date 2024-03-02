using Domain.Entites.Security.Model;
using System;

namespace Domain.Entities.Security.Model
{
    public class UserRoles
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        #region
        public Roles Role { get; set; }
        public Users User { get; set; }
        #endregion

    }
}
