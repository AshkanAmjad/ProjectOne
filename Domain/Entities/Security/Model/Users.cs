using Domain.Entites.Portal.Model;
using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;

namespace Domain.Entites.Security.Model
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        #region Relations
        public ICollection <Articles> Artice { get; set; }
        public ICollection <UserRoles> UserRoles { get; set; }
        #endregion
    }
}
