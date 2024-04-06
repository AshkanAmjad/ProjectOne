using CMS.Models;
using CMS.Models.MemberSip;
using CMS.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bussiness.Security;
using System.Collections.Generic;

namespace CMS.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            //LoginValidator loginValidator = new LoginValidator();
            //ValidationResult res = loginValidator.Validate(login);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            //if (res.IsValid)
            {

                bool result = Membership.ValidateUser(login.UserName, login.Password);
                if (result == true)
                {
                    var user = (CustomMemberShipUser)Membership.GetUser(login.UserName, false);
                    if (user != null)
                    {
                        List<string> roleTitles = new List<string>();
                        if (user.UserRoles.Any())
                        {
                            RoleServices roleService = new RoleServices();
                            var roleIds = user.UserRoles.Select(s => s.RoleId).ToList();
                            roleTitles = roleService.GetRoleTitleList(roleIds);
                        }

                        CustomSerializeModel userModel = new CustomSerializeModel
                        {
                            UserId = user.UserId,
                            Role = roleTitles
                        };
                            
                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                                1, login.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("CAS", enTicket);
                        Response.Cookies.Add(faCookie);

                        return RedirectToAction("Index", "Home");
                    }

                }
                return View();
            }
            //else
            //{
            //    foreach(var failure in res.Errors)
            //    {
            //        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //    }
            //    return View(login);
            //}

        }
    }
}