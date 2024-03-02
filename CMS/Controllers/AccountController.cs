using CMS.Models;
using CMS.Models.Validation;
using CMS.Models.ViewModel;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                        var userModel = new
                        {
                            UserId = user.UserId,
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