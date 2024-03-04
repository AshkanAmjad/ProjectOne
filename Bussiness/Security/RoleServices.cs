using Domain.Data.Context;
using Domain.Entities.Security.Model;
using Microsoft.Ajax.Utilities;
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

        public Role GetRoleWithId(Guid roleId)
        {
            using(CMSContext context = new CMSContext())
            {
                return context.Roles.Where(r => r.RoleId == roleId).FirstOrDefault();
            }
        }

        public bool Similary(string title)
        {
            using(CMSContext context=new CMSContext())
            {
                return context.Roles.Where(r => r.Title == title).Any();
            }
        }

        public bool Add(Role role)
        {
            Role nRole = new Role()
            {
                RoleId = role.RoleId,
                Title = role.Title
            };
            if(Similary(nRole.Title) == true)
            {
                return false;
            }
            using (CMSContext context = new CMSContext())
            {
                context.Roles.Add(nRole);
                context.SaveChanges();
            }
            return true;
        }

        public bool Edit(System.Guid roleId, string title)
        {
            using (CMSContext context = new CMSContext())
            {
                
                var data = context.Roles.Where(r => r.RoleId == roleId).FirstOrDefault();
                if (Similary(title) == true)
                {
                    return false;
                }
                if (data != null)
                {
                    data.RoleId = roleId;
                    data.Title = title;
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
