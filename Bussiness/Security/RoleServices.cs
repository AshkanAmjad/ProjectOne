using Domain.Data.Context;
using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bussiness.Security
{
    public class RoleServices
    {
        public List<Role> GetRoles()
        {
            using (CMSContext context = new CMSContext())
            {
                return context.Roles.AsEnumerable().ToList();
            }
        }

        public bool Add(Role role)
        {
            Role nRole = new Role()
            {
                RoleId = role.RoleId,
                Title = role.Title
            };
            using (CMSContext context = new CMSContext())
            {
                context.Roles.Add(nRole);
                context.SaveChanges();
            }
            return true;
        }

        public bool Edit(System.Guid roleId, Role role)
        {
            using (CMSContext context = new CMSContext())
            {
                var data = context.Roles.Where(r => r.RoleId == roleId).FirstOrDefault();
                if (data != null)
                {
                    data.RoleId = role.RoleId;
                    data.Title = role.Title;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool Delete(Guid roleId)
        {
            using (CMSContext context = new CMSContext())
            {
                var data = context.Roles.Where(r => r.RoleId == roleId).FirstOrDefault();
                if(data != null)
                {
                    context.Roles.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
