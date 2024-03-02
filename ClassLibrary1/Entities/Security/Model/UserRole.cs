using Domain.Entites.Security.Model;
using System;

namespace Domain.Entities.Security.Model
{
    public class UserRole
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        #region
        public Role Role { get; set; }
        public User User { get; set; }
        #endregion

    }
}
