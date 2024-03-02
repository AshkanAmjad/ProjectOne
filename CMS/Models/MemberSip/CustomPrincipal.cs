using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CMS.Models.MemberSip
{
    public class CustomPrincipal:IPrincipal
    {
        #region Identity Properties
        public Guid UserId { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        #region NotImplement
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}