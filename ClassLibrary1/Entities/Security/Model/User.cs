using Domain.Entites.Portal.Model;
using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;

namespace Domain.Entites.Security.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        public ICollection<Article> Articles { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
