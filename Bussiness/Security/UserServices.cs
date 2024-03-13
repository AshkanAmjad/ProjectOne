
using CMS.Models.ViewModels.User;
using Domain.Data.Context;
using Domain.Entites.Security.Model;
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

        public DeleteViewModel GetUserByIdForDelete(Guid userId)
        {
            using (CMSContext context = new CMSContext())
            {
                var user = context.Users.AsNoTracking()
                                        .Where(u => u.UserId == userId)
                                        .Select(x => new DeleteViewModel
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
                                            Password = x.Password,
                                            ConfirmPassword = x.Password,
                                            Email = x.Email,
                                            IsActive = x.IsActive
                                        }).FirstOrDefault();
                return user;
            }
        }

        public bool Similarity(string userName, string email, out string message)
        {
            using (CMSContext context = new CMSContext())
            {
                bool checkUserName = context.Users.Where(u => u.UserName == userName).Any();
                if (checkUserName == true)
                {
                    message = "Duplicated User Name";
                    return checkUserName;
                }

                bool checkEmail = context.Users.Where(u => u.Email == email).Any();
                if (checkEmail == true)
                {
                    message = "Duplicated Email Address";
                    return checkEmail;
                }
                message = "";
                return false;
            }
        }

        public bool Add(AddViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.UserName, model.Email, out checkMessage) == false)
            {
                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = model.IsActive
                };
                using (CMSContext context = new CMSContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
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
            if (Similarity(" ", model.Email, out checkMessage) == false)
            {
                using (CMSContext context = new CMSContext())
                {
                    var data = context.Users.Where(u => u.UserId == model.UserId).FirstOrDefault();
                    if(data != null)
                    {
                        data.UserId = model.UserId;
                        data.Password = model.Password;
                        data.Email = model.Email;
                        data.IsActive = model.IsActive;
                        context.SaveChanges();
                        message = "";
                        return true;
                    }
                } 
            }
            message = checkMessage;
            return false;
        }

        public bool Delete(DeleteViewModel model)
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
                else
                {
                    return false;
                }
            }
        }


    }
}
