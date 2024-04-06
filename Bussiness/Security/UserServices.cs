
using CMS.Models.ViewModels.User;
using Domain.Data.Context;
using Domain.Entites.Security.Model;
using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Models.User;

namespace Bussiness.Security
{
    public class UserServices
    {
        public List<UserViewModel> GetUers()
        {
            using (CMSContext context = new CMSContext())
            {
                var users = context.Users.AsNoTracking()
                                        .Select(x => new UserViewModel
                                        {
                                            UserName = x.UserName,
                                            Email = x.Email,
                                            UserId = x.UserId
                                        }).ToList();
                return users;
            }
        }

        public DeleteUserViewModel GetUserByIdForDelete(Guid userId)
        {
            using (CMSContext context = new CMSContext())
            {
                var user = context.Users.AsNoTracking()
                                        .Where(u => u.UserId == userId)
                                        .Select(x => new DeleteUserViewModel
                                        {
                                            UserId = x.UserId,
                                            UserName = x.UserName
                                        }).FirstOrDefault();
                return user;
            }
        }

        public EditViewModel GetUserByIdForEdit(Guid userId)
        {
            using (CMSContext context = new CMSContext())
            {
                var user = context.Users.AsNoTracking()
                                        .Where(u => u.UserId == userId)
                                        .Select(x => new EditViewModel
                                        {
                                            UserId = x.UserId,
                                            UserName = x.UserName,
                                            Password = x.Password,
                                            ConfirmPassword = x.Password,
                                            Email = x.Email,
                                            IsActive = x.IsActive
                                        }).FirstOrDefault();

                user.RoleIds = context.UserRoles.Where(s => s.UserId == userId)
                                                .Select(s => s.RoleId)
                                                .ToArray();
                return user;
            }
        }

        public bool Similarity(string userId, string userName, string email, out string message)
        {
            using (CMSContext context = new CMSContext())
            {
                bool checkUserName = context.Users.Where(u => u.UserName == userName && u.UserId.ToString() != userId).Any();
                if (checkUserName == true)
                {
                    message = "Duplicated User Name";
                    return checkUserName;
                }

                bool checkEmail = context.Users.Where(u => u.Email == email && u.UserName.ToString() != userName).Any();
                if (checkEmail == true)
                {
                    message = "Duplicated Email Address";
                    return checkEmail;
                }
                message = "";
                return false;
            }
        }

        public bool Add(AddUserViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity("", model.UserName, model.Email, out checkMessage) == false)
            {
                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = model.IsActive,
                };
                using (CMSContext context = new CMSContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                var roles = model.RoleId;
                foreach (var item in roles)
                {
                    UserRole userRoles = new UserRole()
                    {
                        UserId = user.UserId,
                        RoleId = item
                    };
                    using (CMSContext context = new CMSContext())
                    {
                        context.UserRoles.Add(userRoles);
                        context.SaveChanges();
                    }

                }
                message = "";
                return true;
            }
            message = checkMessage;
            return false;
        }

        public bool Edit(EditViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.UserId.ToString(), model.UserName, model.Email, out checkMessage) == false)
            {
                using (CMSContext context = new CMSContext())
                {
                    var data = context.Users.Where(u => u.UserId == model.UserId).FirstOrDefault();
                    if (data != null)
                    {
                        data.UserId = model.UserId;
                        data.Password = model.Password;
                        data.Email = model.Email;
                        data.IsActive = model.IsActive;
                        context.SaveChanges();
                        message = "";
                    }
                    var userRoles = context.UserRoles.Where(r => r.UserId == model.UserId)
                                                     .ToList();

                    var userRoleIds = userRoles.Select(s => s.RoleId)
                                               .ToList();
                    if (userRoles.Any())
                    {
                        if (model.RoleIds.Any())
                        {
                            var mustBeDeleted = userRoleIds.Except(model.RoleIds);
                            var mustBeAdded = model.RoleIds.Except(userRoleIds);

                            if (mustBeDeleted.Any())
                            {
                                var mustBeDeletedRole = userRoles.Where(r => mustBeDeleted.Contains(r.RoleId))
                                                                  .ToList();
                                if (mustBeDeletedRole.Any())
                                {
                                    context.UserRoles.RemoveRange(mustBeDeletedRole);
                                }
                            }
                            if (mustBeAdded.Any())
                            {
                                foreach (var item in mustBeAdded)
                                {
                                    UserRole obj = new UserRole()
                                    {
                                        RoleId = item,
                                        UserId = model.UserId
                                    };
                                    context.UserRoles.Add(obj);
                                }
                            }
                        }
                        else
                        {
                            var users = context.UserRoles.Where(u => u.UserId == model.UserId)
                                                       .ToList();
                            if (users.Any())
                            {
                                context.UserRoles.RemoveRange(users);
                                UserRole userRole = new UserRole()
                                {
                                    UserId = model.UserId,
                                    RoleId = new Guid("00000000-0000-0000-0000-000000000000")
                                };
                                context.UserRoles.Add(userRole);
                            }
                        }
                        context.SaveChanges();
                        message = "";
                        return true;
                    }

                }
            }
            message = checkMessage;
            return false;
        }

        public bool Delete(UserViewModel model)
        {
            using (CMSContext context = new CMSContext())
            {
                var data = context.Users.Where(u => u.UserId == model.UserId && u.IsActive == true).FirstOrDefault();
                if (data != null)
                {
                    context.Users.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }




    }
}
