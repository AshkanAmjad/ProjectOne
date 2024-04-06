using Domain.Entities.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.MemberSip
{
    public class CustomSerializeModel
    {
        public Guid UserId { get; set; }
        public List<string> Role { get; set; }

    }
}