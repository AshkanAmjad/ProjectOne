using Domain.Entites.Security.Model;
using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CMS.Models
{
    public class CustomMemberShipUser:MembershipUser
    {
        #region User Properties

        public Guid UserId { get; set; }
        public IList<UserRole> UserRoles { get; set; }

        #endregion

        public CustomMemberShipUser(User user):base("CustomMembership",user.UserName,user.UserId,user.Email,string.Empty,string.Empty,true,false,DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.UserId;
            UserRoles = user.UserRoles.ToList();
        }
    }
}