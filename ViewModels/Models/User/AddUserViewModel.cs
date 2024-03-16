using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels.User
{
    public class AddUserViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
}