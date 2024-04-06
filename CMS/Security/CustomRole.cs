using Domain.Data.Context;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CMS.Security
{
    public class CustomRole : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }
        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var userRoles = new string[] { };
            using (CMSContext context = new CMSContext())
            {
                var selectedUser = context.Users.Include("Roles")
                                                 .Where(u => u.UserName == username)
                                                 .FirstOrDefault();
                if (selectedUser != null)
                {
                    userRoles = new[] { selectedUser.UserRoles.Select(r => r.Role.Title).ToString() };
                }
                return userRoles.ToArray();
            }
        }

        #region Not Implement
        public override string ApplicationName {
            get
            { 
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}