using CMS.Models;
using CMS.Models.ViewModel;
using Domain.Data.Context;
using System;
using System.Linq;
using System.Web.Security;
using System.Data.Entity;

namespace CMS.Security
{
    public class CustomMemberShip : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            using (CMSContext dbContext = new CMSContext())
            {
                //var user=(from us in dbContext.Users
                //          where string.Compare(username, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                //          && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                //          && us.IsActive == true
                //          select us).FirstOrDefault();
                var user = dbContext.Users.Where(u => u.UserName == username
                                                   && u.Password == password
                                                   && u.IsActive == true)
                                         .FirstOrDefault();

                return (user != null) ? true : false;
            }
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            using (CMSContext dbContext = new CMSContext())
            {
                //var user = (from us in dbContext.Users
                //            where string.Compare(username, us.Username, StringComparison.OrdinalIgnoreCase) == 0
                //            select us).FirstOrDefault();

                var user = dbContext.Users
                                    .Include(s => s.UserRoles)
                                    .FirstOrDefault(u => u.UserName == username);
                if (user == null)
                {
                    return null;
                }
                var selectedUser = new CustomMemberShipUser(user);
                return selectedUser;
            }

        }

        #region NotImplement
        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}